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
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        List<SelectListOption> SelectOptionCities(Guid stateId);
        List<SelectListOption> SelectOptionState();

        ResultDto CreateAccountClub(CreateAccountClub command);
        ResultDto UpdateAccountClub(EditAccountClub command);
        EditAccountClub GetDetailsAccountClub(Guid id);
        JsonResult GetAllAccountClub(JqueryDatatableParam param);
        ResultDto RemoveAccountClub(Guid id);
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
                    return result.Failed(ValidateMessage.DuplicateName);

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
                    return result.Failed(ValidateMessage.DuplicateName);
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
                    return result.Failed(ValidateMessage.DuplicateName);

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
                    return result.Failed(ValidateMessage.DuplicateName);

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
                    return result.Failed(ValidateMessage.DuplicateName);


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
                    return result.Failed(ValidateMessage.DuplicateName);
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
                    return result.Failed(ValidateMessage.DuplicateName);


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
                    return result.Failed(ValidateMessage.DuplicateName);

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


        #region Account Club



        public JsonResult GetAllAccountClub(JqueryDatatableParam param)
        {

            var list = _shopContext.AccountClubs.AsNoTracking();

            if (!string.IsNullOrEmpty(param.SSearch))
            {
                list = list.Where(x =>
                    x.AccClbName.ToLower().Contains(param.SSearch.ToLower())
                    || x.AccClbCode.ToLower().Contains(param.SSearch.ToLower())
                    || x.AccClbMobile.ToLower().Contains(param.SSearch.ToLower()));
            }

            var sortColumnIndex = Convert.ToInt32(_contextAccessor.HttpContext.Request.Query["iSortCol_0"]);
            var sortDirection = _contextAccessor.HttpContext.Request.Query["sSortDir_0"];

            switch (sortColumnIndex)
            {
                case 0:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbName) : list.OrderByDescending(c => c.AccClbName);
                    break;
                case 1:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbCode) : list.OrderByDescending(c => c.AccClbCode);
                    break;
                case 2:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbBrithday) : list.OrderByDescending(c => c.AccClbBrithday);
                    break;
                case 5:
                    list = sortDirection == "asc" ? list.OrderBy(c => c.AccClbMobile) : list.OrderByDescending(c => c.AccClbMobile);
                    break;


                default:
                    {
                        string OrderingFunction(Domain.ShopModels.AccountClub e) => sortColumnIndex == 0 ? e.AccClbName : "";
                        IOrderedEnumerable<Domain.ShopModels.AccountClub> rr = null;

                        rr = sortDirection == "asc"
                            ? list.AsEnumerable().OrderBy((Func<Domain.ShopModels.AccountClub, string>)OrderingFunction)
                            : list.AsEnumerable().OrderByDescending((Func<Domain.ShopModels.AccountClub, string>)OrderingFunction);

                        list = rr.AsQueryable();
                        break;
                    }
            }

            IQueryable<AccountClub> displayResult;
            if (param.IDisplayLength != 0)
                displayResult = list.Skip(param.IDisplayStart)
                .Take(param.IDisplayLength);
            else displayResult = list;
            var totalRecords = list.Count();
            var map = _mapper.Map<List<AccountClubDto>>(displayResult.ToList());



            foreach (var clubTypeDto in map)
            {
                clubTypeDto.AccClbSexText = clubTypeDto.AccClbSex switch
                {
                    1 => "زن",
                    0 => "مرد",
                    _ => clubTypeDto.AccClbSexText
                };

                if (clubTypeDto.AccClbTypUid != null)
                    clubTypeDto.AccClubType = _shopContext.AccountClubTypes.Find(clubTypeDto.AccClbTypUid)?.AccClbTypName;

                if (clubTypeDto.AccRateUid != null)
                    clubTypeDto.AccRatioText = _shopContext.AccountRatings.Find(clubTypeDto.AccRateUid)?.AccRateName;

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

        public ResultDto CreateAccountClub(CreateAccountClub command)
        {
            var result = new ResultDto();
            try
            {
                if (_shopContext.AccountClubs.Any(x => x.AccClbName == command.AccClbName.Fix()))
                    return result.Failed(ValidateMessage.DuplicateName);

                if (_shopContext.AccountClubs.Any(x => x.AccClbCode == command.AccClbCode.Fix()))
                    return result.Failed(ValidateMessage.DuplicateCode);

                if (command.AccClbMobile != "1" && _shopContext.AccountClubs.Any(x => x.AccClbMobile == command.AccClbMobile.Fix() && x.AccClbMobile != "1"))
                    return result.Failed(ValidateMessage.DuplicateMobile);


                var map = _mapper.Map<AccountClub>(command);
                _shopContext.AccountClubs.Add(map);
                _shopContext.SaveChanges();
                return result.Succeeded();

            }
            catch (Exception e)
            {
                _logger.LogError($"حین ثبت کردن مشترک خطای زیر رخ داد {e}");
                return result.Failed("عملیات با خطا مواجه شد، لطفا با پشتیبانی تماس بگیرید.");
            }
        }


        public ResultDto UpdateAccountClub(EditAccountClub command)
        {
            var result = new ResultDto();
            try
            {
                var accClub = _shopContext.AccountClubs.Find(command.AccClbUid);
                if (accClub == null)
                {
                    _logger.LogError($"هیچ رکوردی با این شناسه {command.AccClbUid} یافت نشد");
                    return result.Failed("عملیات با خطا مواجه شد لطفا با پشتیبانی تماس بگیرید.");
                }

                if (_shopContext.AccountClubs.Any(x => x.AccClbName == command.AccClbName.Fix() && x.AccClbUid != command.AccClbUid))
                    return result.Failed(ValidateMessage.DuplicateName);

                if (_shopContext.AccountClubs.Any(x => x.AccClbCode == command.AccClbCode.Fix() && x.AccClbUid != command.AccClbUid))
                    return result.Failed(ValidateMessage.DuplicateCode);

                if (_shopContext.AccountClubs.Any(x => x.AccClbMobile == command.AccClbMobile.Fix() && x.AccClbUid != command.AccClbUid))
                    return result.Failed(ValidateMessage.DuplicateMobile);

                var map = _mapper.Map(command, accClub);
                _shopContext.AccountClubs.Update(map);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception e)
            {
                _logger.LogError($"حین ثبت کردن مشترک خطای زیر رخ داد {e}");
                return result.Failed("عملیات با خطا مواجه شد، لطفا با پشتیبانی تماس بگیرید.");
            }
        }



        public ResultDto RemoveAccountClub(Guid id)
        {
            var result = new ResultDto();
            try
            {
                var accountClub = _shopContext.AccountClubs.Find(id);
                if (accountClub == null)
                {
                    _logger.LogWarning($"Don't Find Any Record With Id {id} On Table AccountClub");
                    return result.Failed("خطای رخ داد، لطفا با پشتیبانی تماس بگرید");
                }

                _shopContext.AccountClubs.Remove(accountClub);
                _shopContext.SaveChanges();
                return result.Succeeded();
            }
            catch (Exception exception)
            {
                _logger.LogError($"هنگام حذف واحد شمارش خطای زیر رخ داد {exception}");
                return result.Failed("هنگام ثبت عملیات خطای رخ داد");
            }
        }


        public EditAccountClub GetDetailsAccountClub(Guid id)
        {
            var accClub = _shopContext.AccountClubs.Find(id);
            if (accClub != null)
            {
                var map = _mapper.Map<EditAccountClub>(accClub);
                map.Account = this.GetSelectOptionAccounts();
                map.ClupType = this.GetSelectOptionClubTypes();
                map.Rating = this.GetSelectOptionRatings();
                map.States = this.SelectOptionState();
                map.SateUid = _shopContext.Cities.Include(x => x.SttU)
                    .SingleOrDefault(x => x.CityUid == accClub.CityUid)?.SttUid;

                map.Cities = SelectOptionCities(map.SateUid ?? Guid.Empty);
                return map;
            }
            _logger.LogError($"هیچ رکوردی با این شناسه {id} یافت نشد");
            throw new NullReferenceException("عملیات با خطا مواجه شد لطفا با پشتیبانی تماس بگیرید.");

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


        public List<SelectListOption> SelectOptionState()
        {
            return _shopContext.States.Select(x => new { x.SttName, x.SttUid }).Select(x => new SelectListOption() { Id = x.SttUid, Name = x.SttName }).AsNoTracking().ToList();
        }

        public List<SelectListOption> SelectOptionCities(Guid stateId)
        {
            return _shopContext.Cities.Where(x => x.SttUid == stateId).Select(x => new { x.CityName, x.CityUid }).Select(x => new SelectListOption() { Id = x.CityUid, Name = x.CityName }).AsNoTracking().ToList();
        }
    }

    public class AccountSelectOption
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

    }

    public class SelectListOption
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }


}

