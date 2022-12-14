// <auto-generated/>
namespace Codehard.Functional.AspNetCore;

public static class OptionExtensions
{
    public static Aff<A> ToAffWithFailToOK<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToOK(errorMessage);

    public static Aff<A> ToAffWithFailToCreated<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToCreated(errorMessage);

    public static Aff<A> ToAffWithFailToAccepted<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToAccepted(errorMessage);

    public static Aff<A> ToAffWithFailToNoContent<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToNoContent(errorMessage);

    public static Aff<A> ToAffWithFailToBadRequest<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToBadRequest(errorMessage);

    public static Aff<A> ToAffWithFailToUnauthorized<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToUnauthorized(errorMessage);

    public static Aff<A> ToAffWithFailToForbidden<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToForbidden(errorMessage);

    public static Aff<A> ToAffWithFailToNotFound<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToNotFound(errorMessage);

    public static Aff<A> ToAffWithFailToConflict<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToConflict(errorMessage);

    public static Aff<A> ToAffWithFailToUnprocessableEntity<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToUnprocessableEntity(errorMessage);

    public static Aff<A> ToAffWithFailToLocked<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToLocked(errorMessage);

    public static Aff<A> ToAffWithFailToInternalServerError<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToAff().MapFailToInternalServerError(errorMessage);

    public static Eff<A> ToEffWithFailToOK<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToOK(errorMessage);

    public static Eff<A> ToEffWithFailToCreated<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToCreated(errorMessage);

    public static Eff<A> ToEffWithFailToAccepted<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToAccepted(errorMessage);

    public static Eff<A> ToEffWithFailToNoContent<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToNoContent(errorMessage);

    public static Eff<A> ToEffWithFailToBadRequest<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToBadRequest(errorMessage);

    public static Eff<A> ToEffWithFailToUnauthorized<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToUnauthorized(errorMessage);

    public static Eff<A> ToEffWithFailToForbidden<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToForbidden(errorMessage);

    public static Eff<A> ToEffWithFailToNotFound<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToNotFound(errorMessage);

    public static Eff<A> ToEffWithFailToConflict<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToConflict(errorMessage);

    public static Eff<A> ToEffWithFailToUnprocessableEntity<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToUnprocessableEntity(errorMessage);

    public static Eff<A> ToEffWithFailToLocked<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToLocked(errorMessage);

    public static Eff<A> ToEffWithFailToInternalServerError<A>(this Option<A> ma, string errorMessage = "")
        => ma.ToEff().MapFailToInternalServerError(errorMessage);
}