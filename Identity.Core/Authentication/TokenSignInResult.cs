using System;
using System.Text.Json.Serialization;
using Identity.Core.Model;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Authentication;

public class TokenSignInResult<TKey> : SignInResult
	where TKey : IComparable<TKey>, IEquatable<TKey>
{
	public User<TKey> User { get; protected set; }
	public string Token { get; protected set; }
	[JsonIgnore] // refresh token is returned in http only cookie
	public string RefreshToken { get; protected set; }

	/// <summary>
	/// Returns a <see cref="SignInResult"/> that represents a successful sign-in.
	/// </summary>
	/// <returns>A <see cref="SignInResult"/> that represents a successful sign-in.</returns>
	[NotNull]
	public static TokenSignInResult<TKey> SuccessFrom([NotNull] User<TKey> user, [NotNull] string token, [NotNull] string refreshToken)
	{
		return new TokenSignInResult<TKey>
		{
			Succeeded = true,
			User = user,
			Token = token,
			RefreshToken = refreshToken
		};
	}
}