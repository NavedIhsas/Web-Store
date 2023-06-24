using Application.BaseData.Dto;
using Application.Common;
using AutoMapper;
using Domain.ShopModels;

namespace Application.BaseData
{
    internal class BaseDataMapping:Profile
    {
        public BaseDataMapping()
        {
            //unit
            this.CreateMap<CreateUnit, UnitOfMeasurement>()
                .ForMember(x => x.UomUid, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.UomName, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UomCode, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.UomStatus, opt => opt.MapFrom(x => x.Status));
           
            this.CreateMap<UnitOfMeasurement, UnitDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.UomUid))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.UomName))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.UomCode))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.UomStatus));
           
            this.CreateMap<EditUnit, UnitOfMeasurement>()
                .ForMember(x => x.UomUid, opt => opt.MapFrom(x => x.Id ))
                .ForMember(x => x.UomName, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UomCode, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.UomStatus, opt => opt.MapFrom(x => x.Status)).ReverseMap();

            //wareHouse
             this.CreateMap<CreateWareHouse, WareHouse>()
                .ForMember(x => x.WarHosUid, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.WarHosName, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.WarHosCode, opt => opt.MapFrom(x => x.Code))
                .ForMember(x => x.WarHosStatus, opt => opt.MapFrom(x => x.Status));

             this.CreateMap<WareHouse, WareHouseDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.WarHosUid    ))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.WarHosName))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.WarHosCode))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.WarHosStatus ));


             //Account Clup
             this.CreateMap<AccountClubType, AccountClubTypeDto>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AccClbTypUid))
                 .ForMember(x => x.Name, opt => opt.MapFrom(x => x.AccClbTypName))
                 .ForMember(x => x.PriceInvoice, opt => opt.MapFrom(x => x.AccClbTypDefaultPriceInvoice))
                 .ForMember(x => x.DiscountType, opt => opt.MapFrom(x => x.AccClbTypDiscountType))
                 .ForMember(x => x.DetDiscount, opt => opt.MapFrom(x => x.AccClbTypDetDiscount))
                 .ForMember(x => x.PercentDiscount, opt => opt.MapFrom(x => x.AccClbTypPercentDiscount));

             this.CreateMap<CreateAccountClubType, AccountClubType>()
                 .ForMember(x => x.AccClbTypUid, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.AccClbTypName, opt => opt.MapFrom(x => x.Name))
                 .ForMember(x => x.AccClbTypDefaultPriceInvoice, opt => opt.MapFrom(x => x.PriceInvoice))
                 .ForMember(x => x.AccClbTypDiscountType, opt => opt.MapFrom(x => x.DiscountType))
                 .ForMember(x => x.AccClbTypPercentDiscount, opt => opt.MapFrom(x => x.PercentDiscount))
                 .ForMember(x => x.AccClbTypDetDiscount, opt => opt.MapFrom(x => x.DetDiscount));
           
             this.CreateMap<UpdateAccountClubType, AccountClubType>()
                 .ForMember(x => x.AccClbTypUid, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.AccClbTypName, opt => opt.MapFrom(x => x.Name))
                 .ForMember(x => x.AccClbTypDefaultPriceInvoice, opt => opt.MapFrom(x => x.PriceInvoice))
                 .ForMember(x => x.AccClbTypDiscountType, opt => opt.MapFrom(x => x.DiscountType))
                 .ForMember(x => x.AccClbTypPercentDiscount, opt => opt.MapFrom(x => x.PercentDiscount))
                 .ForMember(x => x.AccClbTypDetDiscount, opt => opt.MapFrom(x => x.DetDiscount));

             //Account Rating
             this.CreateMap<AccountRating, AccountRatingDto>()
                 .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AccRateUid))
                 .ForMember(x => x.Name, opt => opt.MapFrom(x => x.AccRateName));
              
             this.CreateMap<CreateAccountRating, AccountRating>()
                 .ForMember(x => x.AccRateUid, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.AccRateName, opt => opt.MapFrom(x => x.Name));
             
              this.CreateMap<UpdateAccountRating, AccountRating>()
                 .ForMember(x => x.AccRateUid, opt => opt.MapFrom(x => x.Id))
                 .ForMember(x => x.AccRateName, opt => opt.MapFrom(x => x.Name));


              this.CreateMap<CreateAccountClub, AccountClub>().ForMember(x=>x.AccClbBrithday,opt=>opt.MapFrom(x=>x.ShamsiBirthDay.ToGeorgianDateTime()));
              this.CreateMap<EditAccountClub, AccountClub>().ForMember(x => x.AccClbBrithday, opt => opt.MapFrom(x => x.ShamsiBirthDay.ToGeorgianDateTime())).ReverseMap(); 
              this.CreateMap<AccountClub, AccountClubDto>().ForMember(x=>x.ShamsiBirthDay,opt=>opt.MapFrom(x=>x.AccClbBrithday.ToFarsi()));
        }
    }
}
