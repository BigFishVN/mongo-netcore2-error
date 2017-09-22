namespace Helper.Extensions
{
    using Models.Entities;
    using Models.Model;

    public static class ReferenceViewExtensions
    {
        public static ReferenceView ToReferenceView<T>(this T entity)
        {
            if (entity == null)
            {
                return null;
            }

            var tempModel = entity as BaseEntity;
            if (tempModel == null)
            {
                return null;
            }

            var view = new ReferenceView
                           {
                               Code = tempModel.Code,
                               Name = tempModel.Name,
                               ReferenceType = typeof(T).Name
                           };
            return view;
        }
    }
}