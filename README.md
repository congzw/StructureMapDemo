# StructureMapDemo

demo for StructureMap use with MVC5 and WebApi2

## todolist

- 1 [x] add projects place holder
    1.1 Mvc => ~/Empty/Index OK
    1.2 WebApi => ~/api/EmptyApi OK
- 2 [] add mvc di support
- 3 [] add webapi di support

## project relations

- Common
- Domain -> Common
- Web -> Common
- Web.Dependencies -> Common, Domains

Web has no ref with Web.Dependencies, witch is auto copied to "..\Demos.Web\bin"