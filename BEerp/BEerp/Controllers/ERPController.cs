using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEerp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEerp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private Employee dummyEmployee = new Employee
        {
            id = 0,
            name = "__"
        };
        public ERPController(ApplicationDbContext context)
        {
            _context = context;
        }

        /**************************/
        /* Actions for the Login  */
        /**************************/
        [EnableCors("MyPolicy")]
        [HttpGet("Login/{user}/{password}/")]
        public ActionResult<Employee> GetLogin(string user, string password)
        {
            try
            {
                //var employee = _context.Employees.Find(user, password);
                var employee = _context.Employees.Where(a => a.user == user && a.password == password).Single();
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*******************************/
        /* Actions for the Order Table */
        /*******************************/

        // GET: api/<ERPController/Orders>
        [HttpGet("Orders/")]
        public ActionResult<List<Order>> GetAllOrders()
        {
            try
            {
                var listOrder = _context.Orders.ToList();
                return Ok(listOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ERPController>/Orders/5
        [HttpGet("Orders/{id}/")]
        public ActionResult<Order> GetOrder(int id)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }
            
                return Ok(order);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ERPController/Orders>
        [HttpPost("Orders/")]
        public ActionResult PostOrder([FromBody] Order order)
        {
            try
            {
                _context.Add(order);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ERPController>/Orders/5
        [HttpPut("Orders/{id}/")]
        public ActionResult PutOrder(int id, [FromBody] Order order)
        {
            try
            {
                if(id!=order.id)
                {
                    return BadRequest();
                }
                _context.Entry(order).State = EntityState.Modified;
                _context.Update(order);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ERPController>/Orders/5
        [HttpDelete("Orders/{id}/")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }                
                _context.Remove(order);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /**********************************/
        /* Actions for the Customer Table */
        /**********************************/
        // GET: api/<ERPController>
        [HttpGet("Customer/")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            try
            {
                var listCustomer = _context.Customers.ToList();
                return Ok(listCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ERPController>/5
        [HttpGet("Customer/{id}/")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ERPController>
        [HttpPost("Customer/")]
        public ActionResult PostCustomer([FromBody] Customer customer)
        {
            try
            {
                _context.Add(customer);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ERPController>/5
        [HttpPut("Customer/{id}/")]
        public ActionResult PutCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                if (id != customer.id)
                {
                    return BadRequest();
                }
                _context.Entry(customer).State = EntityState.Modified;
                _context.Update(customer);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ERPController>/5
        [HttpDelete("Customer/{id}/")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer == null)
                {
                    return NotFound();
                }
                _context.Remove(customer);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*********************************/
        /* Actions for the Product Table */
        /*********************************/
        // GET: api/<ERPController>
        [HttpGet("Product/")]
        public ActionResult<List<Customer>> GetAllProducts()
        {
            try
            {
                var listProduct = _context.Products.ToList();
                return Ok(listProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ERPController>/5
        [HttpGet("Product/{id}/")]
        public ActionResult<Product> GetProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ERPController>
        [HttpPost("Product/")]
        public ActionResult PostProduct([FromBody] Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ERPController>/5
        [HttpPut("Product/{id}/")]
        public ActionResult PutProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.id)
                {
                    return BadRequest();
                }
                _context.Entry(product).State = EntityState.Modified;
                _context.Update(product);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ERPController>/5
        [HttpDelete("Product/{id}/")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Remove(product);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /**********************************/
        /* Actions for the Employee Table */
        /**********************************/
        // GET: api/<ERPController>
        [HttpGet("Employee/")]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            try
            {
                var listEmployee = _context.Employees.ToList();
                return Ok(listEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ERPController>/5
        [HttpGet("Employee/{id}/")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ERPController>
        [HttpPost("Employee/")]
        public ActionResult PostEmployee([FromBody] Employee employee)
        {
            try
            {
                _context.Add(employee);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ERPController>/5
        [HttpPut("Employee/{id}/")]
        public ActionResult PutEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                if (id != employee.id)
                {
                    return BadRequest();
                }
                _context.Entry(employee).State = EntityState.Modified;
                _context.Update(employee);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ERPController>/5
        [HttpDelete("Employee/{id}/")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                var product = _context.Employees.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Remove(product);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}


