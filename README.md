# StructureMapDemo

demo for StructureMap use with MVC5 and WebApi2

## todolist

- 1 [x] add projects place holder
    - 1.1 Mvc => ~/Empty/Index OK
    - 1.2 WebApi => ~/api/EmptyApi OK
- 2 [x] add mvc di support
    - 2.1 add StructureMap.MVC5 to Web.Dependencies
    - 2.2 fix StructureMap config
    - 2.3 Mvc => ~/Foo/Index OK
    - 2.4 Mvc => ~/Foo/IndexEx OK    
- 3 [x] add webapi di support
    - 3.1 add StructureMap.WebApi2 to Web.Dependencies
    - 3.2 fix StructureMap config
    - 3.3 webapi => ~/api/foo OK : commit tx
    - 3.4 webapi => ~/api/fooEx OK : rollback tx

## project relations

- Common
- Domain -> Common
- Web -> Common
- Web.Dependencies -> Common, Domains

Web has no ref with Web.Dependencies, witch is auto copied to "..\Demos.Web\bin"