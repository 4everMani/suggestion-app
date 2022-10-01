using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Utilities.Mapper
{
    public abstract class DtoModelMapperBase<TDtoIn, TModelOut> where TDtoIn : class where TModelOut : new()
    {
        public abstract TModelOut MapToModel(TDtoIn dto);

        public IEnumerable<TModelOut> MapToModel(IEnumerable<TDtoIn> dtolList)
        {
            foreach (var dto in dtolList)
            {
                yield return this.MapToModel(dto);
            }
        }
    }
}
