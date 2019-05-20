using IMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IMSRepository.Utilities
{
    public class ItemRequestFormDataAccess : IItemRequestFormDataAccess
    {
        public ItemRequestFormDataAccess()
        {

        }

        public ItemRequestForm GetItemRequestFormById(int Id)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemRequestForms
                    .Include(x => x.Quotations)
                    .Include(x => x.ItemRequestFormMappings.Select(y => y.Item))
                    .Include(x => x.ItemRequestFormMappings.Select(z => z.Item.Brand))
                    .Include(x => x.CodeDetail)
                    .Include(x => x.ItemRequestFormMappings).Where(x => x.Id == Id)
                    .FirstOrDefault();

                return result;
            }
        }

        public List<ItemRequestFormSearchResultModel> GetItemRequestFormSearchResults(ItemRequestFormSearchQueryModel query)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemRequestFormSearch_SP(query.ModuleNm, query.Id.HasValue ? query.Id.Value.ToString() : null, 
                    String.IsNullOrEmpty(query.Title) ? null : query.Title, query.StatusCd.HasValue ? query.StatusCd.Value.ToString() : null,
                    string.IsNullOrEmpty(query.DateCreated) ? null : query.DateCreated, string.IsNullOrEmpty(query.DateTo) ? null : query.DateTo)
                    .Select(x => new ItemRequestFormSearchResultModel {
                        Id = x.Id,
                        Title = x.Title,
                        Status = x.CodeValue,
                        DateCreated = x.CreateDttm
                    }).ToList();

                return result;
            }
        }

        public CodeHeader GetAllFollowupDetails()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.CodeHeaders.Include("CodeDetails").Where(x => x.CodeHeaderName.Equals("Item Request Followup Days")).FirstOrDefault();

                return result;
            }
        }

        public List<ItemRequestDelinquentQueryResultModel> GetItemRequestFormDelinquents(ItemRequestDelinquentQueryModel query)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemRequestFormSearch_SP(query.ModuleNm, null, null,
                            query.FirstFollowupDate.ToString(), query.SecondFollowupDate.ToString(),
                            query.ThirdFollowupDate.ToString())
                            .Select(x => new ItemRequestDelinquentQueryResultModel
                            {
                                Id = x.Id,
                                Title = x.Title,
                                Status = x.CodeValue,
                                TicketStatus = x.TicketStatus,
                                DateCreated = x.CreateDttm
                            })
                            .ToList();

                return result;
            }
        }

        public CodeHeader GetAllTicketStatus()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.CodeHeaders.Include("CodeDetails").Where(x => x.CodeHeaderName.Equals("Ticket Status")).FirstOrDefault();

                return result;
            }
        }

        public ItemRequestForm InsertNewItemRequest(ItemRequestForm itemRequest)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                context.ItemRequestForms.Add(itemRequest);
                context.Entry(itemRequest).State = EntityState.Added;
                int result = context.SaveChanges();

                return result > 0 ? itemRequest : new ItemRequestForm();
            }
        }

        public bool UpdateItemRequestById(ItemRequestForm itemRequest)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var item = context.ItemRequestForms.Where(x => x.Id == itemRequest.Id).FirstOrDefault();

                item.Id = itemRequest.Id;
                item.Title = itemRequest.Title;
                item.UpdateDttm = itemRequest.UpdateDttm;
                item.UpdateUserName = itemRequest.UpdateUserName;

                context.Entry(item).State = EntityState.Modified;
                int result = context.SaveChanges();

                return result > 0 ? true : false;
            }
        }
    }
}
