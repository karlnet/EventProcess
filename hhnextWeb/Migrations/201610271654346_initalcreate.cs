namespace hhnextWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceGroups",
                c => new
                    {
                        DeviceGroupId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        DeviceGroupNo = c.String(),
                        DeviceGroupName = c.String(),
                    })
                .PrimaryKey(t => t.DeviceGroupId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceNo = c.String(nullable: false, maxLength: 8, fixedLength: true, unicode: false),
                        DeviceName = c.String(nullable: false),
                        DeviceGroupId = c.Int(nullable: false),
                        DeviceType = c.String(),
                        DriverId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        MAC = c.String(),
                        ROMVersion = c.String(),
                        PrivateIP = c.String(),
                        PublicIP = c.String(),
                        SSID = c.String(),
                        BSSID = c.String(),
                        Token = c.String(),
                        Config = c.String(),
                        Address = c.String(),
                        Manufacturer = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        Status = c.String(),
                        Comments = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                        Offtime = c.DateTime(),
                        Onlinetime = c.DateTime(),
                        Createtime = c.DateTime(),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.DeviceGroups", t => t.DeviceGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DeviceNo, unique: true, name: "IX_Devices_DeviceNo")
                .Index(t => t.DeviceGroupId)
                .Index(t => t.DriverId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.DevicePorts",
                c => new
                    {
                        PortId = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        PortNo = c.String(nullable: false),
                        PortName = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                        DevicePortGroupId = c.Int(nullable: false),
                        PortType = c.String(),
                        Enable = c.String(),
                        DataType = c.String(nullable: false),
                        Uplimit = c.Decimal(precision: 18, scale: 2),
                        Lowlimit = c.Decimal(precision: 18, scale: 2),
                        UpOffset = c.Decimal(precision: 18, scale: 2),
                        LowOffset = c.Decimal(precision: 18, scale: 2),
                        Max = c.Decimal(precision: 18, scale: 2),
                        Min = c.Decimal(precision: 18, scale: 2),
                        DefaultValue = c.String(nullable: false),
                        Permission = c.String(),
                        IP = c.String(),
                        Config = c.String(),
                        Address = c.String(),
                        Comments = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                    })
                .PrimaryKey(t => t.PortId)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .ForeignKey("dbo.DevicePortGroups", t => t.DevicePortGroupId, cascadeDelete: true)
                .Index(t => t.DeviceId)
                .Index(t => t.DevicePortGroupId);
            
            CreateTable(
                "dbo.DevicePortGroups",
                c => new
                    {
                        DevicePortGroupId = c.Int(nullable: false, identity: true),
                        DevicePortGroupNo = c.String(),
                        DevicePortGroupName = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DevicePortGroupId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectNo = c.String(nullable: false),
                        ProjectName = c.String(nullable: false),
                        AppId = c.String(),
                        AppSecretKey = c.String(),
                        Comments = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Int(nullable: false),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoleDeviceGroups",
                c => new
                    {
                        RoleDeviceGroupId = c.Int(nullable: false, identity: true),
                        DeviceGroupId = c.Int(nullable: false),
                        read = c.Boolean(nullable: false),
                        write = c.Boolean(nullable: false),
                        exec = c.Boolean(nullable: false),
                        item = c.Boolean(nullable: false),
                        AppRole_Id = c.String(maxLength: 128),
                        AppRole_Id1 = c.String(maxLength: 128),
                        AppRole_Id2 = c.String(maxLength: 128),
                        DevicePortGroup_DevicePortGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.RoleDeviceGroupId)
                .ForeignKey("dbo.AppRoles", t => t.AppRole_Id)
                .ForeignKey("dbo.DeviceGroups", t => t.DeviceGroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppRoles", t => t.AppRole_Id1)
                .ForeignKey("dbo.AppRoles", t => t.AppRole_Id2)
                .ForeignKey("dbo.DevicePortGroups", t => t.DevicePortGroup_DevicePortGroupId)
                .Index(t => t.DeviceGroupId)
                .Index(t => t.AppRole_Id)
                .Index(t => t.AppRole_Id1)
                .Index(t => t.AppRole_Id2)
                .Index(t => t.DevicePortGroup_DevicePortGroupId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.ProjectUser",
                c => new
                    {
                        ProjectUserId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.ProjectUserId)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NickName = c.String(),
                        UserToken = c.String(),
                        UserKey = c.String(),
                        UserType = c.String(),
                        Createtime = c.DateTime(nullable: false),
                        Comments = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AppUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverNo = c.String(nullable: false),
                        DriverName = c.String(nullable: false),
                        Location = c.String(),
                        ClassType = c.String(),
                        Comments = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                        Item4 = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.RoleDevicePortGroups",
                c => new
                    {
                        RoleDevicePortGroupId = c.Int(nullable: false, identity: true),
                        DevicePortGroupId = c.Int(nullable: false),
                        read = c.Boolean(nullable: false),
                        write = c.Boolean(nullable: false),
                        exec = c.Boolean(nullable: false),
                        item = c.Boolean(nullable: false),
                        AppRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleDevicePortGroupId)
                .ForeignKey("dbo.AppRoles", t => t.AppRole_Id)
                .ForeignKey("dbo.DevicePortGroups", t => t.DevicePortGroupId, cascadeDelete: true)
                .Index(t => t.DevicePortGroupId)
                .Index(t => t.AppRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleDevicePortGroups", "DevicePortGroupId", "dbo.DevicePortGroups");
            DropForeignKey("dbo.RoleDevicePortGroups", "AppRole_Id", "dbo.AppRoles");
            DropForeignKey("dbo.Devices", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.RoleDeviceGroups", "DevicePortGroup_DevicePortGroupId", "dbo.DevicePortGroups");
            DropForeignKey("dbo.ProjectUser", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectUser", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserRoles", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserLogins", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.AspNetUserClaims", "AppUser_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Devices", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.DevicePortGroups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.DeviceGroups", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.RoleDeviceGroups", "AppRole_Id2", "dbo.AppRoles");
            DropForeignKey("dbo.RoleDeviceGroups", "AppRole_Id1", "dbo.AppRoles");
            DropForeignKey("dbo.RoleDeviceGroups", "DeviceGroupId", "dbo.DeviceGroups");
            DropForeignKey("dbo.RoleDeviceGroups", "AppRole_Id", "dbo.AppRoles");
            DropForeignKey("dbo.AppRoles", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.DevicePorts", "DevicePortGroupId", "dbo.DevicePortGroups");
            DropForeignKey("dbo.DevicePorts", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Devices", "DeviceGroupId", "dbo.DeviceGroups");
            DropIndex("dbo.RoleDevicePortGroups", new[] { "AppRole_Id" });
            DropIndex("dbo.RoleDevicePortGroups", new[] { "DevicePortGroupId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.ProjectUser", new[] { "AppUserId" });
            DropIndex("dbo.ProjectUser", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.RoleDeviceGroups", new[] { "DevicePortGroup_DevicePortGroupId" });
            DropIndex("dbo.RoleDeviceGroups", new[] { "AppRole_Id2" });
            DropIndex("dbo.RoleDeviceGroups", new[] { "AppRole_Id1" });
            DropIndex("dbo.RoleDeviceGroups", new[] { "AppRole_Id" });
            DropIndex("dbo.RoleDeviceGroups", new[] { "DeviceGroupId" });
            DropIndex("dbo.AppRoles", "RoleNameIndex");
            DropIndex("dbo.AppRoles", new[] { "ProjectId" });
            DropIndex("dbo.DevicePortGroups", new[] { "ProjectId" });
            DropIndex("dbo.DevicePorts", new[] { "DevicePortGroupId" });
            DropIndex("dbo.DevicePorts", new[] { "DeviceId" });
            DropIndex("dbo.Devices", new[] { "ProjectId" });
            DropIndex("dbo.Devices", new[] { "DriverId" });
            DropIndex("dbo.Devices", new[] { "DeviceGroupId" });
            DropIndex("dbo.Devices", "IX_Devices_DeviceNo");
            DropIndex("dbo.DeviceGroups", new[] { "ProjectId" });
            DropTable("dbo.RoleDevicePortGroups");
            DropTable("dbo.Drivers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AppUsers");
            DropTable("dbo.ProjectUser");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RoleDeviceGroups");
            DropTable("dbo.AppRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.DevicePortGroups");
            DropTable("dbo.DevicePorts");
            DropTable("dbo.Devices");
            DropTable("dbo.DeviceGroups");
        }
    }
}
