// https://curiosity-driven.org/monads-in-javascript
// type constructor

interface M<T> {

}

// unit function that wrap a value of underlying type into a monad
function unit<T>(value: T): M<T> {
    return null;
}

// chains the operation on a monadic values
function bind<T, U>(instance: M<T>, transform: (value:T) => M<U>) : M<U> {
    return null;
}

// 1. bind(unit(x),f) == f(x)
// 2. bind(m, unit) == m
// 3. bind(bind(m,f),g) == bind(m, x => bind(f(x,x), g))

function Identity(value) {
    this.value = value;
}

Identity.prototype.bind = function(transform) {
    return transform(this.value);
};

Identity.prototype.toString = function() {
    return 'Identity(' + this.value + ')';
};

var log = console.log;

var rs = new Identity(5).bind(value => 
    new Identity(6).bind(value2 => 
        new Identity(value + value2)));

log(rs);
