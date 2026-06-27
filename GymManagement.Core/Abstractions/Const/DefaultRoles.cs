namespace GymManagement.Core.Abstractions.Const;

public static class DefaultRoles
{
    public partial class Admin
    {
        public const string Name = nameof(Admin);
        public const string Id = "0197cf4a-ac5d-7eef-a708-093bf42c7564";
        public const string ConcurrencyStamp = "0197cf4a-ac5d-7eef-a708-093cfad648ba";
    }


    public partial class Member
    {
        public const string Name = nameof(Member);
        public const string Id = "0197cf4a-ac5d-7eef-a708-093d426d0794";
        public const string ConcurrencyStamp = "0197cf4a-ac5d-7eef-a708-093e31470a2b";
    }


}
