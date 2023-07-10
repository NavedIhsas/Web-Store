using Application.Common;
using Application.Interfaces.Context;
using Application.Product.ProductDto;
using AutoMapper;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Application.Product.Category.ProductCategory;

namespace Application.Product.Category;

/// <summary>
///     product level
/// </summary>
public interface IProductCategory
{
    List<ProductLevelDto> GetLevelList();
    public List<ProductLevelDto> GetParentLevelList();
    int GetSubCodeCount();
    int GetMainCodeCount();
    string GetPrdLvlCheck(string groupId);
    ResultDto<List<ProductLevelDto>> CreatePrdCategory(CreateProductLevel command);
    ResultDto Remove(Guid id);
    string GetMaxProductLvlCodeVal(bool noMax, string groupId = null);
    bool CheckExistCode(string id, string code, string currentId = "");
    CreateProductLevel GetDetails(string id);
    bool EditExistCode(string id, string code);
    ResultDto<List<ProductLevelDto>> EditPrdCategory(CreateProductLevel command);
    List<SelectOption> SelectOptions();
    List<TaxSelectOptionDto> TaxSelectOption();
  
}

public class ProductCategory : IProductCategory
{
    private readonly IShopContext _context;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<ProductCategory> _logger;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public ProductCategory(IMapper mapper, IShopContext context, IHttpContextAccessor contextAccessor,
        ILogger<ProductCategory> logger, IProductService productService)
    {
        _context = context;
        _contextAccessor = contextAccessor;
        _logger = logger;
        _productService = productService;
        _mapper = mapper;
    }

    public ResultDto<List<ProductLevelDto>> CreatePrdCategory(CreateProductLevel command)
    {
        var result = new ResultDto<List<ProductLevelDto>>();
        try
        {
            var fakeParentId = "0";
            if (command.ParentId.HasValue)
                fakeParentId = command.Id.ToString();
            if (CheckExistCode(fakeParentId, command.Code))
                return result.Failed("رکوردی با این کد از قبل وجود دارد");

            if (_context.ProductLevels.Any(x => x.PrdLvlName == command.Name.Fix()))
                return result.Failed("رکوردی با این نام از قبل وجود دارد");

            command.ParsCode = int.Parse(command.Code);
            var map = _mapper.Map<ProductLevel>(command);
            _context.ProductLevels.Add(map);
            _context.SaveChanges();
            return result.Succeeded(GetLevelList());
        }
        catch (Exception e)
        {
            _logger.LogError($"حین ثبت گروه کالا ها خطای زیر رخ داد {e}");
            return result.Failed("عملیات با خطا مواجه شد");
        }
    }

    public ResultDto<List<ProductLevelDto>> EditPrdCategory(CreateProductLevel command)
    {
        var result = new ResultDto<List<ProductLevelDto>>();
        try
        {
            var fakeParentId = "0";
            if (command.ParentId.HasValue)
                fakeParentId = command.Id.ToString();
            if (CheckExistCode(fakeParentId, command.Code, command.Id.ToString()))
                return result.Failed("رکوردی با این کد از قبل وجود دارد");

            if (_context.ProductLevels.Any(x => x.PrdLvlName == command.Name.Fix() && x.PrdLvlUid != command.Id))
                return result.Failed("رکوردی با این نام از قبل وجود دارد");

            command.ParsCode = int.Parse(command.Code);
            var map = _mapper.Map<ProductLevel>(command);
            _context.ProductLevels.Update(map);
            _context.SaveChanges();
            return result.Succeeded(GetLevelList());
        }
        catch (Exception e)
        {
            _logger.LogError($"حین ثبت گروه کالا ها خطای زیر رخ داد {e}");
            return result.Failed("عملیات با خطا مواجه شد");
        }
    }

    public List<SelectOption> SelectOptions()
    {
        return _context.ProductLevels.Select(x => new { x.PrdLvlUid, x.PrdLvlName })
            .Select(x => new SelectOption
            {
                PrdLvlName = x.PrdLvlName,
                PrdLvlUId = x.PrdLvlUid
            }).ToList();
    }

    public List<TaxSelectOptionDto> TaxSelectOption()
    {
        return _context.Taxes.Select(x => new { x.TaxUid, x.TaxName })
            .Select(x => new TaxSelectOptionDto { Id = x.TaxUid, Name = x.TaxName }).ToList();
    }

    public ResultDto Remove(Guid id)
    {
        var result = new ResultDto();
        try
        {
            var productLevel = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == id);
            if (productLevel == null) return result.Failed("هیچ رکوردی با این شناسه یافت نشد");
            _context.ProductLevels.Remove(productLevel);
            _context.SaveChanges();
            return result.Succeeded();
        }
        catch (Exception e)
        {
            _logger.LogError($"حین حذف گروه کالا با شناسه {id} خطای زیر رخ داد {e}");
            return result.Failed("عملیات با خطا مواجه شد");
        }
    }


    public bool CheckExistCode(string id, string code, string currentId = "")
    {
        var result = false;
        if (id == "0")
            return _context.ProductLevels.Any(x => x.PrdLvlParentUid == null && x.PrdLvlCodeValue == code);

        if (string.IsNullOrEmpty(currentId))
            result = _context.ProductLevels.Any(x => x.PrdLvlParentUid != null && x.PrdLvlCodeValue == code);
        else result = _context.ProductLevels.Any(x => x.PrdLvlCodeValue == code && x.PrdLvlUid != new Guid(currentId));

        return result;
    }

    public bool EditExistCode(string id, string code)
    {
        return _context.ProductLevels.Any(x => x.PrdLvlUid != new Guid(id) && x.PrdLvlCodeValue == code);
    }

  
    public CreateProductLevel GetDetails(string id)
    {
        var result = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlParentUid == new Guid(id));
        return _mapper.Map<CreateProductLevel>(result);
    }

    public string GetPrdLvlCheck(string groupId)
    {
        var result = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == new Guid(groupId));
        return result?.PrdLvlCodeValue;
    }


    public string GetMaxProductLvlCodeVal(bool noMax, string groupId = null)
    {
        try
        {
            if (noMax && groupId == "0")
                return "";

            if (groupId is null or "0")
                return _context.ProductLevels.Where(x => x.PrdLvlParentUid == null).Max(x => x.PrdLvlCodeValue);
            var result = _context.ProductLevels.Where(x => x.PrdLvlParentUid == new Guid(groupId))
                .Max(x => x.PrdLvlCodeValue);

            if (result == null)
                return _context.ProductLevels.Where(x => x.PrdLvlUid == new Guid(groupId)).Max(x => x.PrdLvlCodeValue);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return null;
        }
    }



    public ResultDto<ProductDetails> 
    public List<ProductLevelDto> GetLevelList()
    {
        var result = _context.ProductLevels.AsNoTracking().Select(x => new ProductLevelDto
        {
            Id = x.PrdLvlUid,
            Name = x.PrdLvlName,
            Status = x.PrdLvlStatus,
            ParentId = x.PrdLvlParentUid,
            Code = x.PrdLvlCodeValue,
            CodeValue = x.PrdLvlCode
        }).ToList();

        foreach (var sub in result)
            sub.Sub = _context.ProductLevels.SingleOrDefault(x => x.PrdLvlUid == sub.ParentId)?.PrdLvlName;
        return result;
    }


    public int GetMainCodeCount()
    {
        var result = _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountMainGroupCode)
            ?.SetValue;
        return result != null ? int.Parse(result) : 0;
    }

    public int GetSubCodeCount()
    {
        var result = _context.Settings.SingleOrDefault(x => x.SetKey == ConstantParameter.DigitCountSubGroupCode)
            ?.SetValue;
        return result != null ? int.Parse(result) : 0;
    }

    public List<ProductLevelDto> GetParentLevelList()
    {
        var parent = _context.ProductLevels.Where(x => x.PrdLvlParentUid == null).AsNoTracking().ToList();
        return _mapper.Map<List<ProductLevelDto>>(parent).ToList();
    }

    public class ProductLevelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public Guid? ParentId { get; set; }
        public string Sub { get; set; }
        public string Code { get; set; }
        public string CodeValue { get; set; }
    }

    public class CreateProductLevel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public Guid? ParentId { get; set; }
        public string CodeValue { get; set; }
        public string Code { get; set; }
        public int ParsCode { get; set; }
    }

    public class SelectOption
    {
        public Guid PrdLvlUId { get; set; }
        public string PrdLvlName { get; set; }
    }

    public class TaxSelectOptionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }


    public class InvoiceStatus
    {
        public Guid Id { get; set; }
        public string StatusPay { get; set; }
        public string StatusSubmit { get; set; }

    }
}


