using ReapymentSchedule.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReapymentSchedule.Models;
using System.Reflection;
using ReapymentSchedule.Product;

namespace ReapymentSchedule.Models
{
    public class Manager : IManager
    {
        private Dictionary<string, Type> _products;
        private Dictionary<string,Type> _calculators;
        public Manager()
        {
            LoadProducts();
            LoadCalculators();
        }

        private void LoadCalculators()
        {
            _calculators = new Dictionary<string, Type>();
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterface(typeof(ICalc).ToString()) != null))
            {
                _calculators.Add(item.Name.ToLower(), item);
            }  
        }

        private void LoadProducts()
        {
            _products = new Dictionary<string, Type>();
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterface(typeof(IProduct).ToString()) != null))
            {
                _products.Add(item.Name, item);
            }
        }

        public IProduct CreateProduct(InputData data)
        {
            Type product = GetTypeToCreate(data.Type.ToString(),_products);

            return Activator.CreateInstance(product) as IProduct;
        }
        public ICalc CreateCalculator(InputData data)
        {
            Type calc = GetTypeToCreate(data.InstallmentType.ToString(), _calculators);

            return Activator.CreateInstance(calc,data) as ICalc;
        }

        private Type GetTypeToCreate(string searchName,Dictionary<string,Type> searchIn)
        {
            return searchIn.Where(x => x.Key.ToLower().Contains(searchName.ToLower())).Select(x => x.Value).FirstOrDefault();
        }
    }
}