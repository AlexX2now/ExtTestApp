﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOTVETINAVOPROSII
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OtvetiNaVoprosiEntities : DbContext
    {
        public OtvetiNaVoprosiEntities()
            : base("name=OtvetiNaVoprosiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Должности> Должности { get; set; }
        public virtual DbSet<Загадки_и_ответы> Загадки_и_ответы { get; set; }
        public virtual DbSet<Пользователи> Пользователи { get; set; }
        public virtual DbSet<Результаты> Результаты { get; set; }
        public virtual DbSet<Тематика_загадок> Тематика_загадок { get; set; }
    }
}
