
## Main.fsx

```fsharp

let value = 
    sprintf "My name is %s, I'm %d years old" "Joe" "20" 

// error FS0001: The type 'string' is not compatible with any of t
// ,sbyte,uint16,uint32,uint64,nativeint,unativeint, 
// arising from the use of a printf-style format string
```
