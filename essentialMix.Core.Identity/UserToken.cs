using System;
using System.ComponentModel.DataAnnotations;
using essentialMix.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Model;

[Owned]
[Serializable]
public class UserToken<TKey> : IdentityUserToken<TKey>, IEntity<int>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	[Key]
	public int Id { get; set; }
	public DateTime Created { get; set; }
	public DateTime Expires { get; set; }
	[Required]
	public TKey CreatedBy { get; set; }
	public DateTime? Revoked { get; set; }
	public TKey RevokedBy { get; set; }
	public TKey ReplacedBy { get; set; }

	public bool IsExpired() { return DateTime.UtcNow >= Expires; }

	public bool IsActive() { return Revoked == null && !IsExpired(); }
}