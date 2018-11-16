namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id,SignUpFree,DurationInMonth,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFree,DurationInMonth,DiscountRate) VALUES (2,10,1,15)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFree,DurationInMonth,DiscountRate) VALUES (3,30,3,20)");
            Sql("INSERT INTO MembershipTypes(Id,SignUpFree,DurationInMonth,DiscountRate) VALUES (4,50,5,30)");
        }
        
        public override void Down()
        {
        }
    }
}
