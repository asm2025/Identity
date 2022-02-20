using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using essentialMix.Data.Model;
using essentialMix.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Identity.Model;

[DebuggerDisplay("User: {UserName}, E-mail:{Email}")]
[Serializable]
public class User<TKey> : IdentityUser<TKey>, IEntity<TKey>
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	private string _firstName;
	private string _middleName;
	private string _lastName;

	/// <inheritdoc />
	public User()
	{
	}

	/// <inheritdoc />
	public User(string userName)
		: base(userName)
	{
	}

	[Required]
	[StringLength(255)]
	public string FirstName
	{
		get => _firstName;
		set => _firstName = value.ToNullIfEmpty();
	}

	[StringLength(255)]
	public string MiddleName
	{
		get => _middleName;
		set => _middleName = value.ToNullIfEmpty();
	}

	[Required]
	[StringLength(255)]
	public string LastName
	{
		get => _lastName;
		set => _lastName = value.ToNullIfEmpty();
	}

	public Gender Gender { get; set; }
	public DateTime DateOfBirth { get; set; }
	public DateTime Created { get; set; }
	public DateTime Modified { get; set; }
	public DateTime LastActive { get; set; }

	[Required]
	[StringLength(3, MinimumLength = 3)]
	public string CountryId { get; set; }

	public int? CityId { get; set; }
}