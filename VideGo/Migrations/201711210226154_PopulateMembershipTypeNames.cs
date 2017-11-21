namespace VideGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthy' WHERE id=2");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE id=3");
            Sql("UPDATE MembershipTypes SET Name='Annual' WHERE id=4");

        }

        public override void Down()
        {
        }
    }
}
