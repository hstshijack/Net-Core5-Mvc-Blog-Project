using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBLog.Entities.Concrete;
using ProgrammersBLog.Entities.Dtos;
using ProgrammersBLog.Shared.Utilities.Results.Abstract;
using ProgrammersBLog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBLog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public ArticleManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitofWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article =  _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitofWork.Articles.AddAsync(article);
            await _unitofWork.SaveAsync();
            return new Result(ResultStatus.Success, message: $"{articleAddDto.Title} başlıklı makale başarıyla eklenmiştir");
        }

        public async Task<IResult> Delete(int ArticleId, string modifiedByName)
        {
            var result = await _unitofWork.Articles.AnyAsync(a => a.Id == ArticleId);
            if (result)
            {
                var article = await _unitofWork.Articles.GetAsync(a => a.Id == ArticleId);
                article.IsDeleted = true;
                article.ModifiedByName=modifiedByName;
                article.ModifiedDate=DateTime.Now;
                await _unitofWork.Articles.UpdateAsync(article);
                await _unitofWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"{article.Title} başlıklı makale başarıyla silinmiştir.");

            }
            return new Result(ResultStatus.Error, message: "Böyle bir makale bulunamadı.");
        }

        public async Task<IDataResult<ArticleDto>> Get(int ArticleId)
        {
            var article = await _unitofWork.Articles.GetAsync(a => a.Id == ArticleId,a=>a.users,a=>a.category);
            if(article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Success,data:new ArticleDto
                {
                  
                    Article=article,
                    ResultStatus=ResultStatus.Success,
                });
            }
            return new DataResult<ArticleDto>(ResultStatus.Error, message: "Böyle bir makale bulunamadı", data: null);
        }

        public async  Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles = await _unitofWork.Articles.GetAllAsync(predicate: null, a => a.users, a => a.category);
            if(articles.Count>-1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, data: new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitofWork.Categories.AnyAsync(c=>c.Id==categoryId);
            if (result)
            {
                var articles = await _unitofWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive, a => a.users, a => a.category);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Success, data: new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Success,
                    });
                }
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Böyle bir kategori bulunamadı", data: null);
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeleted()
        {
            var articles = await _unitofWork.Articles.GetAllAsync(a => !a.IsDeleted,a=>a.users,a=>a.category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, data: new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles = await _unitofWork.Articles.GetAllAsync(a=>a.IsActive && !a.IsDeleted, a => a.users, a => a.category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Success, data: new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Success,
                });
            }
            return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Makaleler bulunamadı", data: null);
        }

        public async Task<IResult> HardDelete(int ArticleId)
        {
            var result = await _unitofWork.Articles.AnyAsync(a => a.Id == ArticleId);
            if (result)
            {
                var article = await _unitofWork.Articles.GetAsync(a => a.Id == ArticleId);          
                await _unitofWork.Articles.DeleteAsync(article);
                await _unitofWork.SaveAsync();
                return new Result(ResultStatus.Success, message: $"{article.Title} başlıklı makale başarıyla veritabanından silinmiştir.");

            }
            return new Result(ResultStatus.Error, message: "Böyle bir makale bulunamadı.");
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
           var article= _mapper.Map<Article>(articleUpdateDto);
           article.ModifiedByName = modifiedByName;
           await _unitofWork.Articles.UpdateAsync(article);
           await _unitofWork.SaveAsync();

            return new Result(ResultStatus.Success, message: $"{articleUpdateDto.Title} başlıklı makale başarıyla güncellenmiştir.");


        }
    }
}
