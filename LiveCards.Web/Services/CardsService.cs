using AutoMapper;
using LiveCards.Data;
using LiveCards.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCards.Services
{
    public class CardsService
    {

        private readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public CardsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IQueryable<Card> GetCards(int? categoryId, int? brandId, string keyword = "", bool? active = null, int pageSize = 50, int pageId = 1)
        {


            var data = _context.Cards.Include(x => x.Brand).ThenInclude(x => x.Category).AsQueryable();


            if (brandId != null)
            {
                data = data.Where(x => x.BrandId == brandId);
            }
            else if (categoryId != null)
            {
                data = data.Where(x => x.Brand != null && x.Brand.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(x => x.Name.Contains(keyword));
            }

            if (active != null)
            {
                data = data.Where(x => x.Active == active);
            }

            //data = data.Skip((pageId - 1) * pageSize).Take(pageSize).AsQueryable();
            return data;
        }

        internal List<CardModel> GetCardsForAgent(CardSearchModel model, string userId)
        {

            //var agentCards = _context.AgentCards.Where(x => x.Agent.UserId == userId);

            //var data = agentCards.Select(x => x.Card).Where(x => x.Active && x.IsAvailable)
            //.Include(x => x.Brand).ThenInclude(x => x.Category).AsQueryable();

            model.IsActive = true;
            model.IsAvailable = true; 

            var data = GetFilterCards(model);

         
            //var cards = _mapper.Map<List<CardModel>>(data.ToList());
            var cards = new List<CardModel>();

            return cards;
             
        }

        internal   List<CardModel>  GetCardsForCustomer(CardSearchModel model)
        {

            model.IsActive = true;
            model.IsAvailable = true;

            var data = GetFilterCards(model);

           var cards =  data.Select (x => _mapper.Map<CardModel>(x)).ToList();
           cards.ForEach(x  => x.Price = x.Cost +( x.Cost * x.CustomerPercent) ) ;

            return cards;
        }

        private IQueryable<Card> GetFilterCards(CardSearchModel model )
        {

            var data = _context.Cards.Include(x => x.Brand).ThenInclude(x => x.Category).AsQueryable();


            if (model.Brands != null && model.Brands.Any())
            {
                data = data.Where(x => model.Brands.Contains(x.BrandId));
            }
            else
            if (model.Category != null)
            {
                data = data.Where(x => x.Brand != null && x.Brand.CategoryId == model.Category);
            }

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                data = data.Where(x => x.Name.Contains(model.Keyword));
            }

            if (model.IsActive != null)
            {
                data = data.Where(x => x.Active   == model.IsActive);
            }

            if (model.IsAvailable  != null)
            {
                data = data.Where(x => x.IsAvailable == model.IsAvailable );
            }
             
            return data;
        }
    }
}
