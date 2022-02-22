namespace Delicious.core
{
    public abstract class BaseService<Entity> : IService<Entity> where Entity : BaseEntity
    {
        private readonly IUnitofWork _unitOfWork;
        public BaseService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> add(Entity entity)
        {
            try
            {
                _unitOfWork.Repository<Entity>().add(entity);
                await _unitOfWork.completed();
                return new Response { Status = true, Data = $"Add completely." };
            }
            catch (Exception ex)
            {

                return new Response { Status = false, Error = ex.Message.ToString() };
            }
        }

        public async Task<Response> Edit(Entity entity)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Edit(entity);
                await _unitOfWork.completed();
                return new Response { Status = true, Data = "Modified completely." };
            }
            catch (Exception ex)
            {

                return new Response { Status = false, Error = ex.Message.ToString() };
            }
        }

        public async Task<Response> Remove(Entity entity)
        {
            try
            {
                _unitOfWork.Repository<Entity>().Remove(entity);
                await _unitOfWork.completed();
                return new Response { Status = true, Data = "Removed completely." };
            }
            catch (Exception ex)
            {

                return new Response { Status = false, Error = ex.Message.ToString() };
            }
        }
    }
}