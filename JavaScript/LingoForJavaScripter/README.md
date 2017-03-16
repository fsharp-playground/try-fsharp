
## main.ts

```fsharp

function wrap(foo){
    var bar = [foo];
    return bar;
}

let wrap2 = (n) => [n];

let add = (a,b) => {
    if(typeof a  === 'string' || typeof b === 'string') {
        return Number(a) + Number(b);
    } else if (typeof a == 'number' && typeof b === 'number') {
        return a + b;
    }
};

let log = console.log;
log(add('1', '2'));
log(add(1,2));
```
