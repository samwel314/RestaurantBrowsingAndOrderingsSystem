using Microsoft.EntityFrameworkCore;
using RestaurantSystemDataAccess.Data;
using RestaurantSystemModels.Models;

namespace RestaurantSystemDataAccess.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreatMenu(Menu menu)
        {
            // her we check if this resturant have the same type of menu before 
            var Check = _context.Menus.
                FirstOrDefault(x => x.Type == menu.Type && x.RestaurantId == menu.RestaurantId) ;
            if (Check != null) 
               return false ;

            _context.Menus.Add(menu);   
            var raws = _context.SaveChanges();
            return raws > 0; 
        }

        public Menu ? GetMenu(int id , bool include  )
        {
            //her i will display this menu for user
            //so i need it and some data about Restaurant Then All  Meals In this Menu 
            if (include)
                return
               _context.Menus.AsNoTracking().Include(m=>m.Restaurant ).
                           Include(m=>m.Meals).
                           FirstOrDefault(m => m.Id == id);
            
            // her i need Restaurant id and name for update or Create Reason  
            return
                _context.Menus.AsNoTracking()
                .Include(m=>m.Restaurant).
                FirstOrDefault(m => m.Id == id);   
        }

        public bool UpdateMenu(Menu model)
        {

            var menu = _context.Menus.FirstOrDefault(m => m.Id == model.Id); 
            if (menu == null) 
                return false;
            if (menu.Type !=  model.Type)
            {
                var Check = _context.Menus.
                FirstOrDefault(x => x.Type == model.Type && x.RestaurantId == model.RestaurantId);
                if (Check != null)
                    return false;

                menu.Type = model.Type; 
            }
            
            menu.Description = model.Description;
            menu.UpdatedAt = DateTime.Now;
            _context.Menus.Update(menu);
            var raws = _context.SaveChanges();
            return raws > 0;
        }

        public bool DeleteMenu(int id)
        {
            var model =
                 _context.Menus
                 .FirstOrDefault(x => x.Id == id);
            if (model == null)
                return false;

            _context.Menus.Remove(model);
            _context.SaveChanges();
            return true;

        }
    }
}
