using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll.Base
{
    public class BllBase<T, TDto> : IGenericService<T, TDto> where T : EntityBase where TDto : DtoBase
    {
        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private readonly IGenericRepository<T> _repository;
        #endregion

        public BllBase(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<T>();
            _serviceProvider = serviceProvider;
        }

        public IResponse<TDto> Add(TDto item, bool hasTransactional = true)
        {
            try
            {
                var tResult = _repository.Add(ObjectMapper.Mapper.Map<T>(item));

                if (hasTransactional)
                {
                    SaveChanges();
                }

                return new Response<TDto>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(tResult)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = GetErrorMessage(ex),
                    Data = null
                };
            }
        }

        public IResponse<Task<TDto>> AddAsync(TDto item)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> Delete(TDto item, bool hasTransactional = true)
        {
            try
            {
                var tResult = _repository.Delete(ObjectMapper.Mapper.Map<T>(item));

                if (hasTransactional)
                {
                    SaveChanges();
                }

                return new Response<bool>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<bool>(tResult)
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = GetErrorMessage(ex),
                    Data = false
                };
            }
        }

        public IResponse<Task<bool>> DeleteAsync(TDto item)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> DeleteById(int id, bool hasTransactional = true)
        {
            try
            {
                _repository.Delete(id);

                if (hasTransactional)
                {
                    SaveChanges();
                }

                return new Response<bool>
                {
                    Data = true,
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = GetErrorMessage(ex),
                    Data = false
                };
            }
        }

        public IResponse<Task<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Find(int id)
        {
            try
            {
                return new Response<TDto>
                {
                    Data = ObjectMapper.Mapper.Map<T, TDto>(_repository.Find(id)),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = GetErrorMessage(ex),
                    Data = null
                };
            }
        }

        public IResponse<TDto> Find(Expression<Func<T, bool>> expression, params string[] includes)
        {
            try
            {
                return new Response<TDto>
                {
                    Data = ObjectMapper.Mapper.Map<T, TDto>(_repository.Find(expression,includes)),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = GetErrorMessage(ex),
                    Data = null
                };
            }
        }

        public IResponse<List<TDto>> GetAll(params string[] includes)
        {
            try
            {
                return new Response<List<TDto>>
                {
                    Data = _repository.GetAll(includes).Select(a => ObjectMapper.Mapper.Map<TDto>(a)).ToList(),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    Data = null,
                    Message = GetErrorMessage(ex),
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression, params string[] includes)
        {
            try
            {
                return new Response<List<TDto>>
                {
                    Data = _repository.GetAll(expression,includes).Select(a => ObjectMapper.Mapper.Map<TDto>(a)).ToList(),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new Response<List<TDto>>
                {
                    Data = null,
                    Message = GetErrorMessage(ex),
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public IResponse<IQueryable<T>> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public IResponse<TDto> Update(TDto item, bool hasTransactional)
        {
            try
            {
                var tResult = _repository.Update(ObjectMapper.Mapper.Map<T>(item));

                if (hasTransactional)
                {
                    SaveChanges();
                }

                return new Response<TDto>()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<T, TDto>(tResult)
                };
            }
            catch (Exception ex)
            {
                return new Response<TDto>
                {
                    Data = null,
                    Message = GetErrorMessage(ex),
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public IResponse<Task<TDto>> UpdateAsync(TDto item)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        private string GetErrorMessage(Exception ex)
        {
            var message = "";

            message += ex.Message + Environment.NewLine;
            message += ex.StackTrace + Environment.NewLine;
            if (ex.InnerException != null)
            {
                message += GetErrorMessage(ex.InnerException);
            }

            return message;
        }
    }
}
