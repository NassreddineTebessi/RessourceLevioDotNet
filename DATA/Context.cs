namespace DATA
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using DOMAIN;

    public partial class Context : DbContext
    {
        public Context() : base("Context")
        {
        }

        public virtual DbSet<application> applications { get; set; }
        public virtual DbSet<applicationtest> applicationtests { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<conversation> conversations { get; set; }
        public virtual DbSet<folder> folders { get; set; }
        public virtual DbSet<interview> interviews { get; set; }
        public virtual DbSet<joboffer> joboffers { get; set; }
        public virtual DbSet<leave> leaves { get; set; }
        public virtual DbSet<letter> letters { get; set; }
        public virtual DbSet<mandate> mandates { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<ressource> ressources { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<test> tests { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<application>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<application>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<application>()
                .HasMany(e => e.interviews)
                .WithOptional(e => e.application)
                .HasForeignKey(e => e.application_id);

            modelBuilder.Entity<application>()
                .HasMany(e => e.applicationtests)
                .WithRequired(e => e.application)
                .HasForeignKey(e => e.application_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.projects)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.client_id);

            modelBuilder.Entity<client>()
                .HasMany(e => e.requests)
                .WithMany(e => e.clients)
                .Map(m => m.ToTable("client_request").MapLeftKey("clients_id").MapRightKey("requests_id"));

            modelBuilder.Entity<conversation>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<conversation>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.conversation1)
                .HasForeignKey(e => e.conversation);

            modelBuilder.Entity<folder>()
                .Property(e => e.stateFolder)
                .IsUnicode(false);

            modelBuilder.Entity<folder>()
                .Property(e => e.stateLetter)
                .IsUnicode(false);

            modelBuilder.Entity<folder>()
                .Property(e => e.stateMinister)
                .IsUnicode(false);

            modelBuilder.Entity<folder>()
                .HasMany(e => e.applications)
                .WithOptional(e => e.folder)
                .HasForeignKey(e => e.folder_id);

            modelBuilder.Entity<folder>()
                .HasMany(e => e.letters)
                .WithOptional(e => e.folder)
                .HasForeignKey(e => e.folder_id);

            modelBuilder.Entity<interview>()
                .Property(e => e.stateInterview)
                .IsUnicode(false);

            modelBuilder.Entity<interview>()
                .Property(e => e.typeInterview)
                .IsUnicode(false);

            modelBuilder.Entity<joboffer>()
                .Property(e => e.experience)
                .IsUnicode(false);

            modelBuilder.Entity<joboffer>()
                .Property(e => e.function)
                .IsUnicode(false);

            modelBuilder.Entity<joboffer>()
                .Property(e => e.mission)
                .IsUnicode(false);

            modelBuilder.Entity<joboffer>()
                .Property(e => e.required_profile)
                .IsUnicode(false);

            modelBuilder.Entity<joboffer>()
                .HasMany(e => e.applications)
                .WithOptional(e => e.joboffer)
                .HasForeignKey(e => e.jobOffer_id);

            modelBuilder.Entity<joboffer>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.joboffer)
                .HasForeignKey(e => e.jobOffer_id);

            modelBuilder.Entity<leave>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<letter>()
                .Property(e => e.contratType)
                .IsUnicode(false);

            modelBuilder.Entity<letter>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.message1)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mandates)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<project>()
                .HasMany(e => e.ressources)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<question>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.choice1)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.choice2)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.choice3)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.choice4)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.validChoise)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .Property(e => e.context)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .Property(e => e.resourceType)
                .IsUnicode(false);

            modelBuilder.Entity<request>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.request)
                .HasForeignKey(e => e.request_id);

            modelBuilder.Entity<ressource>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.token)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.contract_type)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.profile)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.sector)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.seniority)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.applications)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.leaves)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.mandates)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.ressource1)
                .WithOptional(e => e.ressource2)
                .HasForeignKey(e => e.assigned_id);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.typeTest)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.version)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.applicationtests)
                .WithRequired(e => e.test)
                .HasForeignKey(e => e.test_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.questions)
                .WithMany(e => e.tests)
                .Map(m => m.ToTable("test_question").MapLeftKey("listTest_id").MapRightKey("listQuestion_id"));

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.token)
                .IsUnicode(false);


        }
    }
}