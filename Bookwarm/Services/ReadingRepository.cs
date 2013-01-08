using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookwarm.Infrastructure;
using Bookwarm.Models;
using NHibernate.Criterion;

namespace Bookwarm.Services
{
    public class ReadingRepository : IReadingRepository
    {
        public void Save(Reading readingToSave)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var reading = session.CreateCriteria<Reading>()
                    .Add(Restrictions.Eq("UserName", readingToSave.UserName))
                    .Add(Restrictions.Eq("Title", readingToSave.Title))
                    .UniqueResult<Reading>();

                if (reading != null)
                {
                    reading.PageNumber = readingToSave.PageNumber;
                    reading.LastUpdate = readingToSave.LastUpdate;
                    session.Update(reading);
                }
                else
                {
                    session.Save(readingToSave);
                }
                transaction.Commit();
            }
        }
    }
}