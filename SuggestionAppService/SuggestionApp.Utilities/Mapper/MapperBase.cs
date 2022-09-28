using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Utilities.Mapper
{
    public abstract class MapperBase<TModel, TDto> where TModel : class where TDto: new()
    {
        public TDto MapToDto(TModel model)
        {
            try
            {
                return this.MapToDtoInternal(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TDto> MapToDto(IEnumerable<TModel> modelList)
        {
            foreach(var model in modelList)
            {
                yield return this.MapToDto(model);
            }
        }

        public TModel MapToModel(TDto dto)
        {
            try
            {
                return this.MapToModelInternal(dto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TModel> MapToModel(IEnumerable<TDto> dtolList)
        {
            foreach (var dto in dtolList)
            {
                yield return this.MapToModel(dto);
            }
        }

        public virtual TDto MapToDtoInternal(TModel model)
        {
            throw new Exception("method not implemented");
        }

        public virtual TModel MapToModelInternal(TDto dto)
        {
            throw new Exception("method not implemented");
        }
    }
}
