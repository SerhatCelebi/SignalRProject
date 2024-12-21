using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;
using System.Reflection;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialmediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialmediaService,IMapper mapper)
        {
            _socialmediaService = socialmediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values =_mapper.Map<List<ResultSocialMediaDto>>(_socialmediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialmedia = new SocialMedia()
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
            };
            _socialmediaService.TAdd(socialmedia);
            return Ok("SocialMedia Kısmı Başarılı Bir Şekilde Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            _socialmediaService.TDelete(value);
            return Ok("SocialMedia Alanı Silindi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialmedia = new SocialMedia()
            {
                SocialMediaID=updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
            };
            _socialmediaService.TUpdate(socialmedia);
            return Ok("SocialMedia Alanı Güncellendi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            return Ok(value);
        }
    }
}
