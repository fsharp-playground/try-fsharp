
using System;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Functional
{
    public class M5 {

        [Fact]
        public void T() {

            IEnumerable<R> ApplySpecialFunctionE<A,R>(IEnumerable<A> sequence, Func<A, IEnumerable<R>> function) {
                foreach(var uw in sequence) {
                    var result = function(uw);
                    foreach(var r in result) {
                        yield return r;
                    }
                }
            }

            async Task<R> ApplySpecialFunctionT<A, R>(Task<A> task, Func<A, Task<R>> function) {
                var uw = await task;
                var result = function(uw);
                return await result;
            }

            Lazy<R> ApplySpecialFunctionL<A, R>(Lazy<A> lazy, Func<A, Lazy<R>> function) {
                return new Lazy<R>(() => {
                    var uw = lazy.Value;
                    var result = function(uw);
                    return result.Value;
                });
            }

            Func<R> ApplySpecialFunctionF<A,R>(Func<A> onDemand, Func<A, Func<R>> function) {
                return () => {
                    var uw = onDemand();
                    var result = function(uw);
                    return result();
                };
            }
            
            Nullable<R> ApplySpecialFunction<A, R>(Nullable<A> nullable, Func<A, Nullable<R>> function)
                where R: struct
                where A: struct
             {
                if(nullable.HasValue) {
                    var uw = nullable.Value;
                    var result = function(uw);
                    return result;
                }else {
                    return new Nullable<R>();
                }
            }

            Nullable<double> SafeLog(int x) {
                if(x > 0)  {
                    return new Nullable<double>(Math.Log(x));
                } else {
                    return new Nullable<double>();
                }
            }

        }
    }
}