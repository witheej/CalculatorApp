using CalculatorApp.Data;
using CalculatorApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApp.Hubs
{
    public class CalculatorHub : Hub
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public CalculatorHub(UserManager<IdentityUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task SubmitExpression(string expression)
        {

            string username = Context.User.Identity.Name;
            IdentityUser user = await _userManager.FindByNameAsync(username);

            SubmittedCalculation sc = new SubmittedCalculation()
            {
                Expression = expression,
                UserId = user.Id
            };

            await _dbContext.AddAsync(sc);
            await _dbContext.SaveChangesAsync();

            string result = Calculator.ComputeResults(expression);

            var test = _dbContext.SubmittedCalculation.ToList();

            await Clients.Caller.SendAsync("ReceiveMessage", result);
        }
    }
}
