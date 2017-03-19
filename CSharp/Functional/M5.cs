
using System;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Functional
{
    public class M5 {

        [Fact]
        public void T() {

            var x = ApplyFunction<int, double>(new Lazy<int>(() => 1), (a) => new Lazy<double>(() => 0.0));

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


            Lazy<R> ApplyFunction<A, R>(Lazy<A> lazy, Func<A, R> function) {
                return new Lazy<R>(() => {
                    var unwraped = lazy.Value;
                    var result = function(unwraped);
                    return result;
                });
            }

            Lazy<R> ApplySpecialFunction<A, R>(Lazy<A> lazy, Func<A, Lazy<R>> function) {
                return new Lazy<R>(() => {
                    var unwraped = lazy.Value;
                     Lazy<R> result = function(unwraped);
                    return result.Value;
                });
            }

            // Don't see how difference
            var lazyInt = new Lazy<int>(() => 100);
            var v1 = ApplyFunction<int, double>(lazyInt, (a) => a / 2);
            var v2 = ApplySpecialFunction<int, double>(lazyInt, (a) => new Lazy<double>(() => a / 2));

            Func<R> ApplySpecialFunctionF<A,R>(Func<A> onDemand, Func<A, Func<R>> function) {
                return () => {
                    var uw = onDemand();
                    var result = function(uw);
                    return result();
                };
            }
            
            Nullable<R> ApplySpecialFunctionN<A, R>(Nullable<A> nullable, Func<A, Nullable<R>> function)
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