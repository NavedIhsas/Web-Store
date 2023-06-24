using System.Collections;
using System.Data;
using Application.BaseData.Dto;
using Application.Common;
using Application.Interfaces.Context;
using AutoMapper;
using Domain.ShopModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using ILogger = Microsoft.Build.Framework.ILogger;

namespace Application.BaseData
{
    public interface IBaseDataService
    {
        JsonResult GetAllUnit(JqueryDatatableParam param);
        ResultDto CreateUnit(CreateUnit command);
        ResultDto<List<UnitDto>> RemoveUnit(Guid id);
        ResultDto UpdateUnit(EditUnit command);

        JsonResult GetAllWareHouse(JqueryDatatableParam param);
        ResultDto CreateWareHouse(CreateWareHouse command);
        ResultDto RemoveWareHouse(Guid id);
        ResultDto UpdateWareHouse(UpdateWareHouse command);

        JsonResult GetAllAccountClupType(JqueryDatatableParam param);
        ResultDto CreateAccountClubType(CreateAccountClubType command);
        ResultDto RemoveAccountClubType(Guid id);
        ResultDto UpdateAccountClubType(UpdateAccountClubType command);

        JsonResult GetAllAccountRating(JqueryDatatableParam param);
        ResultDto CreateAccountRating(CreateAccountRating command);
        ResultDto RemoveAccountRating(Guid id);
        ResultDto UpdateAccountRating(UpdateAccountRating command);


        List<AccountSelectOption> GetSelectOptionAccounts();
        List<AccountClubType> GetSelectOptionClubTypes();
        List<AccountRating> GetSelectOptionRatings();
    }
    internal class BaseDataService : IBaseDataService
    {
        private readonly IShopContext _shopContext;
        private readonly ILogger<BaseDataService> _logger;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public BaseDataService(IShopContext shopContext, ILogger<BaseDataService> logger, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _shopContext = shopContext;
            _logger = logger;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        #region Unit Of Measurements

        public JsonResult GetAllUnit(JqueryDatatableParam param)
        {

            var list = _shopContext.UnitOfMeasurements.AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
                list = list.Where(x => x.UomName.ToLower().Contains(param.SSearch.ToLower()));

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.UomCode) : list.OrderByDescending(c => c.UomCode);
                    break;
                case 4:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.UomName) : list.OrderByDescending(c => c.UomName);
                    break;
                default:
                    {
                        string OrderingFunction(UnitOfMeasurement e) => sortColumnIndex == 0 ? e.UomName : e.UomCode;
                        IOrderedEnumerable<UnitOfMeasurement> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<UnitOfMeasurement, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<UnitOfMeasurement, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<UnitOfMeasurement> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map = _mapper.Map<List<UnitDto>>(displayResult.ToList());

            var result = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = map
            });
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
        public ResultDto CreateUnit(CreateUnit command)
        {
            var result = new ResultDto();
            try
            {
                if (_shopContext.UnitOfMeasurements.Any(x => x.UomName == command.Name.Fix()))
                    return result.Failed(ValidateMessage.Duplicate);

                if (_shopContext.UnitOfMeasurements.Any(x => x.UomCode == command.Code.Fix()))
                    return result.Failed(ValidateMessage.DuplicateCode);


                var unit = _mapper.Map<UnitOfMeasurement>(command);
                _shopContext.UnitOfMeasurements.Add(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ثبت واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        public ResultDto UpdateUnit(EditUnit command)
        {
            var result = new ResultDto();
            try
            {
                var unit = _shopContext.UnitOfMeasurements.Find(command.Id);
                if (unit == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {command.Id} On Table UnitOfMeasurements");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                if (_shopContext.UnitOfMeasurements.Any(x => x.UomName == command.Name.Fix() && x.UomUid != command.Id))
                    return result.Failed(ValidateMessage.Duplicate);
                var addUnit = _mapper.Map(command, unit);
                _shopContext.UnitOfMeasurements.Update(addUnit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ویرایش واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }


        public ResultDto<List<UnitDto>> RemoveUnit(Guid id)
        {
            var result = new ResultDto<List<UnitDto>>();
            try
            {
                var unit = _shopContext.UnitOfMeasurements.Find(id);
                if (unit == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {id} On Table UnitOfMeasurements");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                _shopContext.UnitOfMeasurements.Remove(unit);
                _shopContext.SaveChanges();
                return result.Succeeded(null);
            }

            catch (DbUpdateException ex)
            {
                return result.Failed("این رکورد در جا های دیگری از برنامه استفاده شده و قابل حذف نمیباشد.");
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام حذف واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        #endregion

        #region Unit Of WareHouse


        public JsonResult GetAllWareHouse(JqueryDatatableParam param)
        {

            var list = _shopContext.WareHouses.AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
                list = list.Where(x => x.WarHosName.ToLower().Contains(param.SSearch.ToLower()));

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.WarHosCode) : list.OrderByDescending(c => c.WarHosCode);
                    break;
                case 4:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.WarHosName) : list.OrderByDescending(c => c.WarHosName);
                    break;
                default:
                    {
                        string OrderingFunction(WareHouse e) => sortColumnIndex == 0 ? e.WarHosName : e.WarHosCode;
                        IOrderedEnumerable<WareHouse> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<WareHouse, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<WareHouse, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<WareHouse> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map = _mapper.Map<List<WareHouseDto>>(displayResult.ToList());

            var result = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = map
            });
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }

        public ResultDto CreateWareHouse(CreateWareHouse command)
        {
            var result = new ResultDto();
            try
            {
                if (_shopContext.WareHouses.Any(x => x.WarHosName == command.Name.Fix()))
                    return result.Failed(ValidateMessage.Duplicate);

                if (_shopContext.WareHouses.Any(x => x.WarHosName == command.Code.Fix()))
                    return result.Failed(ValidateMessage.DuplicateCode);

                var unit = _mapper.Map<WareHouse>(command);
                _shopContext.WareHouses.Add(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ثبت واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        public ResultDto UpdateWareHouse(UpdateWareHouse command)
        {
            var result = new ResultDto();
            try
            {
                var wareHouse = _shopContext.WareHouses.Find(command.Id);
                if (wareHouse == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {command.Id} On Table WareHouse");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                if (_shopContext.WareHouses.Any(x => x.WarHosName == command.Name.Fix() && x.WarHosUid != command.Id))
                    return result.Failed(ValidateMessage.Duplicate);

                if (_shopContext.WareHouses.Any(x => x.WarHosCode == command.Code.Fix() && x.WarHosUid != command.Id))
                    return result.Failed(ValidateMessage.DuplicateCode);


                var map = _mapper.Map(command, wareHouse);
                _shopContext.WareHouses.Update(map);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ویرایش واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }


        public ResultDto RemoveWareHouse(Guid id)
        {
            var result = new ResultDto();
            try
            {
                var unit = _shopContext.WareHouses.Find(id);
                if (unit == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {id} On Table WareHouse");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                _shopContext.WareHouses.Remove(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام حذف واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        #endregion

        #region Unit Of AccountClubType



        public JsonResult GetAllAccountClupType(JqueryDatatableParam param)
        {

            var list = _shopContext.AccountClubTypes.AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x =>
                    x.AccClbTypName.ToLower().Contains(param.SSearch.ToLower()));

                if (!list.Any())
                    list = list.Where(x => x.AccClbTypPercentDiscount.ToString().ToLower().Contains(param.SSearch.Fix()));

                if (!list.Any())
                    list = list.Where(x => x.AccClbTypDetDiscount.ToString().ToLower().Contains(param.SSearch.Fix()));

                if (!list.Any())
                    list = list.Where(x => x.AccClbTypDefaultPriceInvoice.ToString().ToLower().Contains(param.SSearch.Fix()));

            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbTypName) : list.OrderByDescending(c => c.AccClbTypName);
                    break;
                case 4:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbTypDefaultPriceInvoice) : list.OrderByDescending(c => c.AccClbTypDefaultPriceInvoice);
                    break;

                case 5:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbTypDiscountType) : list.OrderByDescending(c => c.AccClbTypDiscountType);
                    break;

                case 6:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbTypDetDiscount) : list.OrderByDescending(c => c.AccClbTypDetDiscount);
                    break;


                default:
                    {
                        string OrderingFunction(AccountClubType e) => sortColumnIndex == 0 ? e.AccClbTypName : "";
                        IOrderedEnumerable<AccountClubType> rr = null;

                        rr = sortDirection == "asc"
                            ? list.AsEnumerable().OrderBy((Func<AccountClubType, string>)OrderingFunction)
                            : list.AsEnumerable().OrderByDescending((Func<AccountClubType, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<AccountClubType> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map = _mapper.Map<List<AccountClubTypeDto>>(displayResult.ToList());

            foreach (var clubTypeDto in map)
            {
                clubTypeDto.DiscountTypeText = clubTypeDto.DiscountType switch
                {
                    "0" => "کسر از فاکتور",
                    "1" => "شارژ باشگاه",
                    _ => clubTypeDto.DiscountType
                };

                clubTypeDto.PriceInvoiceText = clubTypeDto.PriceInvoice switch
                {
                    0 => "صفر",
                    1 => "سطح 1",
                    2 => "سطح 2",
                    3 => "سطح 3",
                    4 => "سطح 4",
                    5 => "سطح 5",
                    _ => clubTypeDto.PriceInvoiceText
                };
            }

            var result = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = map
            });
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }





        public ResultDto CreateAccountClubType(CreateAccountClubType command)
        {
            var result = new ResultDto();
            try
            {
                if (_shopContext.AccountClubTypes.Any(x => x.AccClbTypName == command.Name.Fix()))
                    return result.Failed(ValidateMessage.Duplicate);


                var account = _mapper.Map<AccountClubType>(command);
                _shopContext.AccountClubTypes.Add(account);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ثبت واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        public ResultDto UpdateAccountClubType(UpdateAccountClubType command)
        {
            var result = new ResultDto();
            try
            {
                var account = _shopContext.AccountClubTypes.Find(command.Id);
                if (account == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {command.Id} On Table AccountClubType");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                if (_shopContext.AccountClubTypes.Any(x => x.AccClbTypName == command.Name.Fix() && x.AccClbTypUid != command.Id))
                    return result.Failed(ValidateMessage.Duplicate);
                var map = _mapper.Map(command, account);
                _shopContext.AccountClubTypes.Update(map);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ویرایش واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }


        public ResultDto RemoveAccountClubType(Guid id)
        {
            var result = new ResultDto();
            try
            {
                var unit = _shopContext.AccountClubTypes.Find(id);
                if (unit == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {id} On Table AccountClubType");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                _shopContext.AccountClubTypes.Remove(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام حذف واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        #endregion


        #region  AccountRating


        public JsonResult GetAllAccountRating(JqueryDatatableParam param)
        {

            var list = _shopContext.AccountRatings.AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
                list = list.Where(x => x.AccRateName.ToLower().Contains(param.SSearch.ToLower()));

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 3:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccRateName) : list.OrderByDescending(c => c.AccRateName);
                    break;

                default:
                    {
                        string OrderingFunction(AccountRating e) => sortColumnIndex == 0 ? e.AccRateName : "";
                        IOrderedEnumerable<AccountRating> rr = null;
                        rr = sortDirection == "asc" ? list.AsEnumerable().OrderBy((Func<AccountRating, string>)OrderingFunction) : list.AsEnumerable().OrderByDescending((Func<AccountRating, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<AccountRating> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map = _mapper.Map<List<AccountRatingDto>>(displayResult.ToList());

            var result = (new
            {
                param.SEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = map
            });
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }

        public ResultDto CreateAccountRating(CreateAccountRating command)
        {
            var result = new ResultDto();
            try
            {
                if (_shopContext.AccountRatings.Any(x => x.AccRateName == command.Name.Fix()))
                    return result.Failed(ValidateMessage.Duplicate);


                var unit = _mapper.Map<AccountRating>(command);
                _shopContext.AccountRatings.Add(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ثبت رتبه بندی مشترکین خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        public ResultDto UpdateAccountRating(UpdateAccountRating command)
        {
            var result = new ResultDto();
            try
            {
                var AccountRating = _shopContext.AccountRatings.Find(command.Id);
                if (AccountRating == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {command.Id} On Table AccountRating");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                if (_shopContext.AccountRatings.Any(x => x.AccRateName == command.Name.Fix() && x.AccRateUid != command.Id))
                    return result.Failed(ValidateMessage.Duplicate);

                var map = _mapper.Map(command, AccountRating);
                _shopContext.AccountRatings.Update(map);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام ویرایش رتبه بندی مشترکین خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }


        public ResultDto RemoveAccountRating(Guid id)
        {
            var result = new ResultDto();
            try
            {
                var unit = _shopContext.AccountRatings.Find(id);
                if (unit == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {id} On Table AccountRating");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                _shopContext.AccountRatings.Remove(unit);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام حذف ربته بندی مشترکین خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }

        #endregion


        public List<AccountSelectOption> GetSelectOptionAccounts()
        {
            var account = _shopContext.AccountClubs.Select(x => new { x.AccClbName, x.AccClbUid }).AsNoTracking().Select(x => new AccountSelectOption()
            {
                Id = x.AccClbUid,
                Name = x.AccClbName
            }).ToList();
            return account;
        }


        public List<AccountClubType> GetSelectOptionClubTypes()
        {
            var account = _shopContext.AccountClubTypes.Select(x => new { x.AccClbTypName, x.AccClbTypUid }).AsNoTracking().Select(x => new AccountClubType()
            {
                AccClbTypUid = x.AccClbTypUid,
                AccClbTypName = x.AccClbTypName
            }).ToList();
            return account;
        }

        public List<AccountRating> GetSelectOptionRatings()
        {
            var account = _shopContext.AccountRatings.Select(x => new { x.AccRateName, x.AccRateUid }).AsNoTracking().Select(x => new AccountRating()
            {
                AccRateUid = x.AccRateUid,
                AccRateName = x.AccRateName
            }).ToList();
            return account;
        }
    }

    public class AccountSelectOption
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

    }


}

