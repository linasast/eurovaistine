using DrugCompensation.Api.CompensationTypes;
using DrugCompensation.Api.Database;
using DrugCompensation.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrugCompensation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrugPayController : ControllerBase
    {
        private readonly IEnumerable<ICompensationTypeCalculator> _compensationTypeCalculators;
        private readonly DrugContext _ctx;


        public DrugPayController(DrugContext ctx)
        {
            _compensationTypeCalculators = new List<ICompensationTypeCalculator> { new Government(), new HealthInsurance(), new SpecialFund() };
            _ctx = ctx;
            Initialize();
        }


        [HttpGet]
        [Route("[action]")]
        public JsonResult Pay(int drugID, int quantity, double discount, Entities.Type compensationType, Guid compensationTypeID)
        {
            var drug = ResolveDrug(drugID);
            if (drug == null) return new JsonResult(new { message = $"drug with {drugID} unrecognized." });

            var compensation = ResolveCompensation(compensationTypeID);

            if (compensation == null) return new JsonResult(new { message = $"unrecognized {compensationTypeID} as unique identifier." });
            if (!ResolveCompensationType(compensation, compensationType)) return new JsonResult(new { message = $"compensationTypeID: {compensationTypeID} does not match with compensationTypeName." });

            var payableSum = _compensationTypeCalculators.First(c => c.Type == compensationType).Calculate(quantity, drug.RetailPrice, drug.BasicCompensationPrice, drug.CompensationPercent, discount);
            SaveCompensationRecord(new CompensationRecord { CompensationType = compensation, CreateTime = DateTime.Now, Drug = drug, PayableSum = payableSum });

            return new JsonResult(new { payableSum });
        }

        private void SaveCompensationRecord(CompensationRecord record)
        {
            _ctx.CompensationRecords.Add(record);
            _ctx.SaveChanges();
        }

        private Drug ResolveDrug(int id)
        {
            return _ctx.Drugs.FirstOrDefault(d => d.ID == id);
        }

        private Compensation ResolveCompensation(Guid id)
        {
            return _ctx.Compensations.FirstOrDefault(ct => ct.ID == id);
        }

        private bool ResolveCompensationType(Compensation compensation, Entities.Type type)
        {
            return compensation.Type == type;
        }

        private void Initialize()
        {
            _ctx.Database.EnsureCreated();

            if (_ctx.Compensations.Any()) return;

            var compensations = new Compensation[] {
                new Compensation{ ID = Guid.NewGuid(), Type = Entities.Type.Government },
                new Compensation{ ID = Guid.NewGuid(), Type = Entities.Type.HealthInsurance },
                new Compensation{ ID = Guid.NewGuid(), Type = Entities.Type.SpecialFund }
            };

            foreach(var compensation in compensations)
            {
                _ctx.Compensations.Add(compensation);
            }
            _ctx.SaveChanges();

            var drugs = new Drug[] { new Drug { RetailPrice = 9.99, CompensationPercent = 10, BasicCompensationPrice = 8.99 } };

            foreach(var drug in drugs)
            {
                _ctx.Drugs.Add(drug);
            }
            _ctx.SaveChanges();
        }
    }
}
