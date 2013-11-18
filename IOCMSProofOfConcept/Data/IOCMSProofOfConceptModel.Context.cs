﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IOCMSProofOfConcept.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class IOCMSProofOfConceptEntities : DbContext
    {
        public IOCMSProofOfConceptEntities()
            : base("name=IOCMSProofOfConceptEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<InitialClassification> InitialClassifications { get; set; }
        public DbSet<TempClassification> TempClassifications { get; set; }
    
        public virtual int uspInitialClassifications_Delete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspInitialClassifications_Delete", idParameter);
        }
    
        public virtual ObjectResult<InitialClassification> uspInitialClassifications_Get(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InitialClassification>("uspInitialClassifications_Get", idParameter);
        }
    
        public virtual ObjectResult<InitialClassification> uspInitialClassifications_Get(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<InitialClassification>("uspInitialClassifications_Get", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspInitialClassifications_Insert(string name, string description)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspInitialClassifications_Insert", nameParameter, descriptionParameter);
        }
    
        public virtual int uspInitialClassifications_Update(Nullable<int> id, string name, string description)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspInitialClassifications_Update", idParameter, nameParameter, descriptionParameter);
        }
    
        public virtual int uspTempClassifications_Delete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspTempClassifications_Delete", idParameter);
        }
    
        public virtual ObjectResult<TempClassification> uspTempClassifications_Get(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TempClassification>("uspTempClassifications_Get", idParameter);
        }
    
        public virtual ObjectResult<TempClassification> uspTempClassifications_Get(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TempClassification>("uspTempClassifications_Get", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> uspTempClassifications_Insert(string name, string description)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("uspTempClassifications_Insert", nameParameter, descriptionParameter);
        }
    
        public virtual int uspTempClassifications_Update(Nullable<int> id, string name, string description)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspTempClassifications_Update", idParameter, nameParameter, descriptionParameter);
        }
    }
}