namespace SuggestionApp.Utilities.Mapper
{
    public abstract class MapperBase<TModel, TDto> where TModel : class where TDto : new()
    {
        public abstract TDto MapToDto(TModel model);


        public IEnumerable<TDto> MapToDto(IEnumerable<TModel> modelList)
        {
            foreach (var model in modelList)
            {
                yield return this.MapToDto(model);
            }
        }

        public abstract TModel MapToModel(TDto dto);

        public IEnumerable<TModel> MapToModel(IEnumerable<TDto> dtolList)
        {
            foreach (var dto in dtolList)
            {
                yield return this.MapToModel(dto);
            }
        }

    }
}
