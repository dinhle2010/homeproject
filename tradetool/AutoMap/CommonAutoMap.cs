using AutoMapper;
//using CoC.Business.DTO.Common.Request;
//using CoC.Business.Entities.Common;
//using CoC.Business.Entities.Common.SCM;
using System;

namespace tradetool
{
    public class CommonAutoMap : Profile
    {
        protected override void Configure()
        {

            CreateMap<DateTimeOffset?, DateTime?>().ConvertUsing<DateTimeOffsetToDateTimeNullAble>();
            CreateMap<DateTimeOffset, DateTime>().ConvertUsing<DateTimeOffsetToDateTime>();
            CreateMap<Result, BittrexMarketHistory>();


        }

        public class DateTimeOffsetToDateTimeNullAble : ITypeConverter<DateTimeOffset?, DateTime?>
        {
            public DateTime? Convert(DateTimeOffset? source, DateTime? destination, ResolutionContext context)
            {
                if (source == null)
                {
                    return null;
                }
                else
                {
                    return source.Value.DateTime;
                }
            }
        }

        public class DateTimeOffsetToDateTime : ITypeConverter<DateTimeOffset, DateTime>
        {
            public DateTime Convert(DateTimeOffset source, DateTime destination, ResolutionContext context)
            {
                return source.DateTime;
            }
        }
    }
}
