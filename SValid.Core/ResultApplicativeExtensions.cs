using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public static class ResultApplicativeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TResult, List<TError>> Apply<TArg, TError, TResult>(
            in this Result<Func<TArg, TResult>, List<TError>> f,
            in Result<TArg, TError> arg)
        {
            if (f.IsOk() && arg.IsOk())
                return Result<TResult, List<TError>>.CreateOk(f.Ok(arg.Ok));
            else if (f.IsOk() && arg.IsError())
                return Result<TResult, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<TResult, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<TResult, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TResult, List<TError>> Apply<TArg, TError, TResult>(
            in this Result<Func<TArg, TResult>, List<TError>> f,
            in Result<TArg, List<TError>> arg)
        {
            if (f.IsOk() && arg.IsOk())
                return Result<TResult, List<TError>>.CreateOk(f.Ok(arg.Ok));
            else if (f.IsOk() && arg.IsError())
                return Result<TResult, List<TError>>.CreateError(new List<TError>(arg.Error));
            else if (f.IsError() && arg.IsOk())
                return Result<TResult, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<TResult, List<TError>>.CreateError(new List<TError>(f.Error.Concat(arg.Error)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TResult>, List<TError>> Apply<TArg, TArg2, TError, TResult>(
            this Result<Func<TArg, TArg2, TResult>, List<TError>> f,
            Result<TArg, TError> arg)
        {
            TResult BindParam(TArg2 a2) => f.Ok(arg.Ok, a2);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TResult>, List<TError>> Apply<TArg, TArg2, TError, TResult>(
            this Result<Func<TArg, TArg2, TResult>, List<TError>> f,
            Result<TArg, List<TError>> arg)
        {
            TResult BindParam(TArg2 a2) => f.Ok(arg.Ok, a2);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>(arg.Error));
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TResult>, List<TError>>.CreateError(new List<TError>(f.Error.Concat(arg.Error)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TError, TResult>(
                this Result<Func<TArg, TArg2, TArg3, TResult>, List<TError>> f,
                Result<TArg, TError> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3) => f.Ok(arg.Ok, a2, a3);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TError, TResult>(
            this Result<Func<TArg, TArg2, TArg3, TResult>, List<TError>> f,
            Result<TArg, List<TError>> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3) => f.Ok(arg.Ok, a2, a3);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>(arg.Error));
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TResult>, List<TError>>.CreateError(new List<TError>(f.Error.Concat(arg.Error)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TArg4, TError, TResult>(
            this Result<Func<TArg, TArg2, TArg3, TArg4, TResult>, List<TError>> f,
            Result<TArg, TError> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3, TArg4 a4) => f.Ok(arg.Ok, a2, a3, a4);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TArg4, TError, TResult>(
            this Result<Func<TArg, TArg2, TArg3, TArg4, TResult>, List<TError>> f,
            Result<TArg, List<TError>> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3, TArg4 a4) => f.Ok(arg.Ok, a2, a3, a4);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>(arg.Error));
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TArg4, TResult>, List<TError>>.CreateError(new List<TError>(f.Error.Concat(arg.Error)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TArg4, TArg5, TError, TResult>(
            this Result<Func<TArg, TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>> f,
            Result<TArg, TError> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3, TArg4 a4, TArg5 a5) => f.Ok(arg.Ok, a2, a3, a4, a5);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TArg4, TArg5, TResult>, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<Func<TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>> Apply<TArg, TArg2, TArg3, TArg4, TArg5, TArg6, TError, TResult>(
            this Result<Func<TArg, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>> f,
            Result<TArg, TError> arg)
        {
            TResult BindParam(TArg2 a2, TArg3 a3, TArg4 a4, TArg5 a5, TArg6 a6) => f.Ok(arg.Ok, a2, a3, a4, a5, a6);

            if (f.IsOk() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>>.CreateOk(BindParam);
            else if (f.IsOk() && arg.IsError())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>>.CreateError(new List<TError>() { arg.Error });
            else if (f.IsError() && arg.IsOk())
                return Result<Func<TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>>.CreateError(new List<TError>(f.Error));
            else return Result<Func<TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, List<TError>>.CreateError(new List<TError>(f.Error) { arg.Error });
        }
    }
}
