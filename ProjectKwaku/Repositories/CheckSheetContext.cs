using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;

namespace Repositories
{
    public class CheckSheetContext : DbContext, IDbContext
    {
        private readonly string databaseConnectionString;

        public CheckSheetContext(
            DbContextOptions<CheckSheetContext> options,
            IConfiguration configuration) : base(options)
        {
            databaseConnectionString = configuration.GetConnectionString("OpsChecklistDatabase");
        }

        public DbSet<CheckSheet> CheckSheets { get; set; }

        public DbSet<CheckSheetType> CheckSheetTypes { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlServer(databaseConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskStatus>()
                .HasOne(x => x.Task)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CheckSheetType>().HasData(
                new CheckSheetType { CheckSheetTypeId = 1, Name = "EMEA" },
                new CheckSheetType { CheckSheetTypeId = 2, Name = "Oceania" },
                new CheckSheetType { CheckSheetTypeId = 3, Name = "NA" }
            );

            CreateNATasks(builder, 3);


            builder.Entity<CheckSheet>().HasData(
                new CheckSheet
                {
                    CheckSheetId = 1,
                    CheckSheetTypeId = 3,
                    SignOffUserId = null,
                    StartDateUtc = new DateTime(2019, 1, 1),
                    Comment = ""
                },
                new CheckSheet
                {
                    CheckSheetId = 2,
                    CheckSheetTypeId = 2,
                    SignOffUserId = null,
                    StartDateUtc = new DateTime(2019, 1, 1),
                    Comment = ""
                }
            ); ;

            builder.Entity<TaskStatus>().HasData(
                new TaskStatus
                {
                    TaskStatusId = 1,
                    CheckSheetId = 1,
                    TaskId = 1,
                    Comment = "",
                    AssignedUserId = null,
                    State = State.None
                },
                new TaskStatus
                {
                    TaskStatusId = 2,
                    CheckSheetId = 2,
                    TaskId = 2,
                    Comment = "",
                    AssignedUserId = null,
                    State = State.None
                }
            );
        }

        private static void CreateNATasks(ModelBuilder builder, int checklistTypeId)
        {
            builder.Entity<Task>().HasData(
                new Task
                {
                    TaskId = 1,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Production Canada (CSCPRC) Backups Start",
                    Description = "CSCPRC backups will kick off. Emails will be received to monitor backups but ensure that you are logged into CSCPRC and keeping an eye on OPCOMS and job failures. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D770e458edbe4bb80d3a5d602ca961974%26sysparm_rank%3D1%26sysparm_tsqueryId%3D9f34fa9cdb5a734040b62c23ca961923",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 2,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Receive SSL IPI and SSL",
                    Description = "Ops will receive the IPI and SSL Processes email",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3Dc7cb914edb28bb80d3a5d602ca96196d%26sysparm_rank%3D1%26sysparm_tsqueryId%3D8ba436dcdb5a734040b62c23ca961995",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 3,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Confirm All URRs Are Complete",
                    Description = "At this stage there should be no URRs running. You can confirm this using the command in the comments",
                    ActiveDays = (int)(DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri | DaysOfWeek.Sat),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 4,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Release Potential Incomplete URR Job If All URRs Are done",
                    Description = "If all URRs are complete, you can release the POTENTIAL_INCOMPLETE_URRS Job on the HOUSEKEEPING queue. If there are any outstanding URRs the job must be held before it's due to release at 04:30 EST",
                    ActiveDays = (int)(DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri | DaysOfWeek.Sat),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 5,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check POTENTIAL_INCOMPLETE_URR's report that will arrive as an email into the NA Inbox ",
                    Description = "The email will detail any outstanding URR's that need investigation. If there are any coming back on the report, then the SUBMIT_JOBS_AFTER_ALL_URRS will not be triggered. Follow the linked documentation to resolve.",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D6c6590b3db553bc41cd6d776489619cb%26sysparm_rank%3D1%26sysparm_tsqueryId%3D59e47210db9a734040b62c23ca9619a2",
                    ActiveDays = (int)(DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri | DaysOfWeek.Sat),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 6,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check for holding jobs",
                    Description = "Check for holding jobs on production systems.",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 7,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Semi-Annual Optimise Jobs Parallel & Serial Check",
                    Description = "Check if Semi-Annual Optimise Jobs Parallel & Serial need to be scheduled this week and consider the simulation & heads up email that need to be sent to all parties involved",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3Dca43d62edb293bc81cd6d776489619cb%26sysparm_rank%3D1%26sysparm_tsqueryId%3D7db53a50db9a734040b62c23ca961927",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 8,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Send the Linux UAT/CSATSC aborted URR Report.",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 9,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Send Escalated Job Report To Scrip Support",
                    Description = "See Documentation",
                    Url = "\\Brscfp1c\\wrkgroup\\CS Operations\\NA\\Templates\\GTS Operations - Aborted Job Report.msg",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri | DaysOfWeek.Sat),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 10,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Monitor QUICKP Jobs",
                    Description = "QUICKP jobs begin to run on Production, monitor these to completion and add MSGSETUP's to companies where necessary to get the jobs running. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D797f4622dbe53bc81cd6d7764896196b%26sysparm_rank%3D1%26sysparm_tsqueryId%3D20e63ed0db9a734040b62c23ca9619d0",
                    ActiveDays = (int)DaysOfWeek.Sun,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 11,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "DPA Backup Report",
                    Description = "The report will be sent to #GL SO NA Operations mailbox. An SD ticket will need to be raised, report saved onto the W drive & the SD ticket number saved on the NA shift handover. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D17f5d666dba93bc81cd6d7764896194f%26sysparm_rank%3D3%26sysparm_tsqueryId%3D2027f254db9a734040b62c23ca96190b",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 12,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Stop All Defrags",
                    Description = "Stop all currently running defrag processes. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D33495aaedbe93bc81cd6d77648961980%26sysparm_rank%3D3%26sysparm_tsqueryId%3D65573e54db9a734040b62c23ca9619d4",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 13,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Walmart Payroll Processing",
                    Description = "This runs after the URR and is called SPE503_HLDADD_UPDATE_WMT",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3Dd37b610edb68bb80d3a5d602ca961974%26sysparm_rank%3D1%26sysparm_tsqueryId%3D09e7f694db9a734040b62c23ca96194a",
                    ActiveDays = (int)DaysOfWeek.Thu,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 14,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Morning Tasks",
                    Description = "Complete the Umenu option for Morning Tasks. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010260",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 15,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Send NA Shift Report",
                    Description = "Ops will receive the IPI and SSL Processes email",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 16,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Backupdisk Cleanup",
                    Description = "Check Backupdisk space on CSAPRC, CSATSC, CSADSC. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010215",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 17,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "EDC_TST URR",
                    Description = "Include Company EDC_TST to the URR Schedule. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010218",
                    ActiveDays = (int)DaysOfWeek.Wed,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 18,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Stop Networker Backups",
                    Description = "Stop running Server Backups - Kill All (Excluding any groups that have DO_NOT_KILL in the name). See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D17f5d666dba93bc81cd6d7764896194f%26sysparm_rank%3D1%26sysparm_tsqueryId%3D36b93298db9a734040b62c23ca9619be",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 19,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Create Backup Checksheets",
                    Description = "Create Backup Checksheets for both VMS & Server Networker backups. Templates are found in comments section. See Documentation",
                    Url = "W:\\CS Operations\\NA\\Checksheets\\Backup Checksheets",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 20,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check Handover/Service Point for Fast Terms / AD-HOC Processing",
                    Description = "Before running the batch, check the handover/emails to see if there’s any ad-hoc processing this evening that requires special attention. This could be Fast Terminations, in which these need to run at 18:30 EST promptly, or you may be asked to bring forward an update (which doesn’t require any authorisation if from a product support team if to run after 17:00 EST). Or release a certain job after update. There could be multiple things that can be requested.",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 21,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Run SETQUE Command and Change Queue Limits",
                    Description = "Run SETQUE command, confirm all queues are started with STPQ. Start any that arent started. Set all queue limits as detailed in document.",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 22,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "DSM Reports",
                    Description = "Process the Disk Space Monitor Reports sent to the mailbox. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D6449bbbcdb353fc040b62c23ca9619dd%26sysparm_rank%3D5%26sysparm_tsqueryId%3D096a721cdb9a734040b62c23ca961908",
                    ActiveDays = (int)DaysOfWeek.Sun,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 23,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check total number of jobs",
                    Description = "At around 19:30 check check the total number of jobs on the system and fill the totals in on the shift report",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 24,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Workstation Backups Begin",
                    Description = "Snaps for these will begin and then their backups will start shortly after. Emails will be received when these start & complete but ensure that you are logged into a CSABNC session and monitoring for failures and OPCOMS. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D285d16e6db6d3bc81cd6d776489619b5%26sysparm_rank%3D2%26sysparm_tsqueryId%3D6faa725cdb9a734040b62c23ca96199a",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 25,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Queue Limit Changes",
                    Description = "Assuming the UBN and UCB1 URRS and XTRACT Jobs are all complete and the Highprior* queue is drained, then you can run the next set of queue changes. If there are still outstanding UBN and UCB1 jobs then hold off on these changes until 22:30 EST",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 26,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check Canada (CSCPRC) URRs",
                    Description = "Ensure the 16 Canada URRs have started on the CSCPRC Node.",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 27,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "MSGLOGGER Check for Backups",
                    Description = "Logon to Umenu and check the URR MSGLOGGER Status",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3Dc1da698edb68bb80d3a5d602ca96192a%26sysparm_rank%3D3%26sysparm_tsqueryId%3Db9eafe5cdb9a734040b62c23ca9619ae",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 28,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Walmart Payroll Processing - SPE503_HLDADD_UPDATE_WMT",
                    Description = "WEDNESDAY DAY - SAME WEEK AS THE US PAYROLL FILE. RUNS AFTER THE URR. When the WALMART Payroll Proccessing job(SPE503_HLDADD_UPDATE_WMT) is complete, abort the 'CBPEND_PROCESS_WMT' job. Then using the DENT command, delete it to make sure it isn't re-run. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010237",
                    ActiveDays = (int)DaysOfWeek.Wed,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 29,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Bank of New York Mellon - BNY_DAILY_XTRACT Jobs",
                    Description = "Check to see that all BNY_DAILY_XTRACT Jobs are completed",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 30,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Walmart Payroll File Transfer (US)",
                    Description = "MONDAY  ON RECEIPT OF EMAIL - IT IS IMPORTANT THAT YOU CHECK THE DOCUMENTATION AND THE INCLUDED SCHEDULE! See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010237",
                    ActiveDays = (int)DaysOfWeek.Mon,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 31,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Walmart Payroll File Transfer (CANADA)",
                    Description = "TUESDAY ON RECEIPT OF EMAIL - IT IS IMPORTANT THAT YOU CHECK THE DOCUMENTATION AND THE INCLUDED SCHEDULE! See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010237",
                    ActiveDays = (int)DaysOfWeek.Tue,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 32,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "WALMART PAYROLL FILE TRANSFER (RHODE ISLAND)",
                    Description = "TUESDAY ON RECEIPT OF EMAIL - IT IS IMPORTANT THAT YOU CHECK THE DOCUMENTATION AND THE INCLUDED SCHEDULE! See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010237",
                    ActiveDays = (int)DaysOfWeek.Tue,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 33,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Start Defrags for COMMONAPP",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010233e",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 34,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check Daily Outbound BNYM ADR File Transfer",
                    Description = @"Emails with subjects:
                        ##### Pull Outgoing BNYM ADR Transaction File from SCRIP Production (CSAPRC) #####
                        ##### Send Outgoing ADR Transaction Production File to BNY-Mellon #####
                        Should be received by 04:30AM GMT",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010243",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 35,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Start Defrags for the 3 Production Cluster Datadisks",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010233",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 36,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Start Defrags of DUALLOGDISK4 and DUALLOGDISK5",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010233",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 37,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Start Defrags for SCRIPCOYDISK and SCRIPLOGDISK and SCRIPLOG2",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010233",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 38,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check for any overrunning backups on Production. Terminate the ones still running",
                    Description = @"***TIME CRITICAL***
                        JD NW_BCK$CSABN * J:CSAPRC
                        If anything appears, abort it.
                        Terminate clone.
                        Delete entry.

                        * **DO NOT DELETE AFTER MIDNIGHT EST * **",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 39,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Update backup totals on NA shift report",
                    Description = "Around that time we will receive an email with the details of backups, please update totals in the shift report",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 40,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "CSAPRC & Non-Production Snaps Begin",
                    Description = "Snaps for these will begin, starting with production. Emails will be received when these start & complete but ensure that you are logged into a CSABNC session and monitoring for failures and OPCOMS. See Documentation",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsys_kb_id%3D285d16e6db6d3bc81cd6d776489619b5%26sysparm_rank%3D2%26sysparm_tsqueryId%3D6faa725cdb9a734040b62c23ca96199a",
                    ActiveDays = (int)DaysOfWeek.Everyday,
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 41,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Queue Limit Changes",
                    Description = "The MAINURR queue should complete all its URRs by 00:00. Assuming the DAY queue is no higher than 4000 you can run the next set of queue changes. On a month end you may see this time vary. If the queue count is high it’s a good idea to let the DAY queues drain to around 4000 before running the changes, therefore on a month end you will probably need to hold off for an hour or so before making these changes.",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                },
                new Task
                {
                    TaskId = 42,
                    CheckSheetTypeId = checklistTypeId,
                    Title = "Check for Long Running URRs",
                    Description = "At this point most of the main URRS should be done (unless it’s a month end) and we are just waiting for the rest at 03:00. It’s a good idea to check what is left. ",
                    Url = "https://computershare.service-now.com/nav_to.do?uri=%2Fkb_view.do%3Fsysparm_article%3DKB0010195",
                    ActiveDays = (int)(DaysOfWeek.Mon | DaysOfWeek.Tue | DaysOfWeek.Wed | DaysOfWeek.Thu | DaysOfWeek.Fri),
                    StartTimeUtc = new TimeSpan(1, 0, 0),
                    ValidFromDateUtc = new DateTime(2019, 1, 1),
                    ValidUntilDateUtc = null
                }
            ); ;
        }
    }
}
