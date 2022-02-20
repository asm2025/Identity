using System;
using System.Diagnostics;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Identity.Model;

[DebuggerDisplay("User: {UserId} - Role: {RoleId}")]
[Serializable]
public class UserRole<TKey> : IdentityUserRole<TKey>, IEntity
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
}