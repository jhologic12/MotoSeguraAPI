á
ZC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\TrayectoValidatorRequestValidator.cs
	namespace 	
MotoSeguraAPI
 
. 

Validators "
{ 
public 

class 
TrayectoValidator "
:# $
AbstractValidator% 6
<6 7
TrayectoDto7 B
>B C
{ 
public		 
TrayectoValidator		  
(		  !
)		! "
{

 	
RuleFor 
( 
x 
=> 
x 
. 
FechaInicio &
)& '
.' (
NotEmpty( 0
(0 1
)1 2
;2 3
RuleFor 
( 
x 
=> 
x 
. 
FechaFin #
)# $
.$ %
GreaterThan% 0
(0 1
x1 2
=>3 5
x6 7
.7 8
FechaInicio8 C
)C D
;D E
RuleFor 
( 
x 
=> 
x 
.  
VelocidadPromedioKmH /
)/ 0
.0 1 
GreaterThanOrEqualTo1 E
(E F
$numF G
)G H
;H I
RuleFor 
( 
x 
=> 
x 
. 
VerificacionCasco ,
., -
Casco_Detectado- <
)< =
. 
Equal 
( 
true 
) 
. 
WithMessage (
(( )
$str) \
)\ ]
;] ^
} 	
} 
} Á
HC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\GpsDtoValidator.cs
	namespace 	
MotoSeguraApi
 
. 

Validators "
{# $
public 

class 
GpsDtoValidator  
:! "
AbstractValidator# 4
<4 5
GpsDto5 ;
>; <
{ 
public 
GpsDtoValidator 
( 
)  
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
	Velocidad		 $
)		$ %
.

  
GreaterThanOrEqualTo

 %
(

% &
$num

& '
)

' (
. 
WithMessage 
( 
$str B
)B C
;C D
RuleFor 
( 
x 
=> 
x 
. 
Altitud "
)" #
.  
GreaterThanOrEqualTo %
(% &
$num& '
)' (
. 
WithMessage 
( 
$str @
)@ A
;A B
RuleFor 
( 
x 
=> 
x 
. 
	Direccion $
)$ %
. 
InclusiveBetween !
(! "
$num" #
,# $
$num% (
)( )
. 
WithMessage 
( 
$str L
)L M
;M N
RuleFor 
( 
x 
=> 
x 
. 
	Ubicacion $
)$ %
. 
NotNull 
( 
) 
. 
SetValidator 
( 
new !#
CoordenadasDtoValidator" 9
(9 :
): ;
); <
;< =
} 	
} 
} Ï
OC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\GiroscopioDtoValidator.cs
	namespace 	
MotoSeguraApi
 
. 

Validators "
{# $
public 

class "
GiroscopioDtoValidator '
:( )
AbstractValidator* ;
<; <
GiroscopioDto< I
>I J
{ 
public "
GiroscopioDtoValidator %
(% &
)& '
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 !
CambioBruscoDireccion		 0
)		0 1
.		1 2
NotNull		2 9
(		9 :
)		: ;
;		; <
}

 	
} 
} ˆ	
PC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\CoordenadasDtoValidator.cs
	namespace 	
MotoSeguraApi
 
. 

Validators "
{" #
public 

class #
CoordenadasDtoValidator (
:) *
AbstractValidator+ <
<< =
CoordenadasDto= K
>K L
{ 
public #
CoordenadasDtoValidator &
(& '
)' (
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
Lat		 
)		 
.

 
InclusiveBetween

 !
(

! "
-

" #
$num

# %
,

% &
$num

' )
)

) *
. 
WithMessage 
( 
$str D
)D E
;E F
RuleFor 
( 
x 
=> 
x 
. 
Lng 
) 
. 
InclusiveBetween !
(! "
-" #
$num# &
,& '
$num( +
)+ ,
. 
WithMessage 
( 
$str G
)G H
;H I
} 	
} 
} ∏
QC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\ConectividadDtoValidator.cs
	namespace 	
MotoSeguraApi
 
. 

Validators "
{ 
public 

class $
ConectividadDtoValidator )
:* +
AbstractValidator, =
<= >
ConectividadDto> M
>M N
{ 
public $
ConectividadDtoValidator '
(' (
)( )
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
RedMovil		 #
)		# $
.		$ %
NotNull		% ,
(		, -
)		- .
;		. /
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
Wifi

 
)

  
.

  !
NotNull

! (
(

( )
)

) *
;

* +
} 	
} 
} ˛
QC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Validators\AcelerometroDtoValidator.cs
	namespace 	
MotoSeguraApi
 
. 

Validators "
;" #
public 
class $
AcelerometroDtoValidator %
:& '
AbstractValidator( 9
<9 :
AcelerometroDto: I
>I J
{ 
public		 
$
AcelerometroDtoValidator		 #
(		# $
)		$ %
{

 
RuleFor 
( 
x 
=> 
x 
. 
Aceleracion "
)" #
. 
InclusiveBetween 
( 
- 
$num "
," #
$num$ '
)' (
;( )
RuleFor 
( 
x 
=> 
x 
. 
FrenadoBrusco $
)$ %
. 
NotNull 
( 
) 
; 
} 
} í
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\UserService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
{		 
public

 

class

 
UserService

 
:

 
IUserService

 +
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public 
UserService 
(  
ApplicationDbContext /
context0 7
)7 8
{ 	
_context 
= 
context 
; 
} 	
public 
User 
? 
FindById 
( 
Guid "
id# %
)% &
{ 	
return 
_context 
. 
Users !
.! "
FirstOrDefault" 0
(0 1
u1 2
=>3 5
u6 7
.7 8
Id8 :
==; =
id> @
)@ A
;A B
} 	
public 
async 
Task 
< 
User 
? 
>  
FindByEmailAsync! 1
(1 2
string2 8
email9 >
)> ?
{ 	
return 
await 
_context !
.! "
Users" '
.' (
FirstOrDefaultAsync( ;
(; <
u< =
=>> @
uA B
.B C
EmailC H
==I K
emailL Q
)Q R
;R S
} 	
public 
bool 
Exists 
( 
Guid 
id  "
)" #
{ 	
return 
_context 
. 
Users !
.! "
Any" %
(% &
u& '
=>( *
u+ ,
., -
Id- /
==0 2
id3 5
)5 6
;6 7
}   	
public## 
UserProfileDto## 
?## 

GetProfile## )
(##) *
ClaimsPrincipal##* 9
user##: >
)##> ?
{$$ 	
var%% 
userIdClaim%% 
=%% 
user%% "
.%%" #
FindFirstValue%%# 1
(%%1 2

ClaimTypes%%2 <
.%%< =
NameIdentifier%%= K
)%%K L
;%%L M
if&& 
(&& 
!&& 
Guid&& 
.&& 
TryParse&& 
(&& 
userIdClaim&& *
,&&* +
out&&, /
var&&0 3
userId&&4 :
)&&: ;
)&&; <
return'' 
null'' 
;'' 
var)) 
entity)) 
=)) 
FindById)) !
())! "
userId))" (
)))( )
;))) *
if** 
(** 
entity** 
==** 
null** 
)** 
return++ 
null++ 
;++ 
return-- 
new-- 
UserProfileDto-- %
{.. 
Id// 
=// 
entity// 
.// 
Id// 
,// 
Name00 
=00 
entity00 
.00 
Name00 "
,00" #
Email11 
=11 
entity11 
.11 
Email11 $
}22 
;22 
}33 	
}55 
}66 ã 
WC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\TrayectoServices\TrayectoService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
TrayectoService! 0
{ 
public 

class 
TrayectoService  
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public 
TrayectoService 
(  
ApplicationDbContext 3
context4 ;
,; <
IMapper= D
mapperE K
)K L
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public  
TrayectoAnalizadoDto #&
ProcesarTrayectoFinalizado$ >
(> ?
TrayectoDto? J
dtoK N
,N O
GuidP T
userIdU [
)[ \
{ 	
var 
trayecto 
= 
_mapper "
." #
Map# &
<& '
Models' -
.- .
Trayecto. 6
>6 7
(7 8
dto8 ;
); <
;< =
trayecto 
. 
UserId 
= 
userId $
;$ %
trayecto 
= %
AnalizadorTrayectoService 0
.0 1
EnriquecerTrayecto1 C
(C D
trayectoD L
,L M
dtoN Q
)Q R
;R S
_context 
. 
	Trayectos 
. 
Add "
(" #
trayecto# +
)+ ,
;, -
_context   
.   
SaveChanges    
(    !
)  ! "
;  " #
var"" 
cumpleNormas"" 
="" 
EvaluadorNormativo"" 1
.""1 2
CumpleNormas""2 >
(""> ?
trayecto""? G
)""G H
;""H I
var$$ 
usuario$$ 
=$$ 
_context$$ "
.$$" #
Users$$# (
.$$( )
Find$$) -
($$- .
userId$$. 4
)$$4 5
;$$5 6
var%% 
medallas%% 
=%% 
usuario%% "
is%%# %
not%%& )
null%%* .
?&& 
RecompensaService&& #
.&&# $
EvaluarMedallas&&$ 3
(&&3 4
trayecto&&4 <
,&&< =
usuario&&> E
)&&E F
:'' 
new'' 
List'' 
<'' 
string'' !
>''! "
(''" #
)''# $
;''$ %
var)) 
sugerencias)) 
=)) 
cumpleNormas)) *
?))+ ,
new))- 0
List))1 5
<))5 6
string))6 <
>))< =
())= >
)))> ?
:))@ A%
ContenidoEducativoService))B [
.))[ \
Sugerir))\ c
())c d
trayecto))d l
)))l m
;))m n
return++ 
new++  
TrayectoAnalizadoDto++ +
{,, 
CumpleNormas-- 
=-- 
cumpleNormas-- +
,--+ ,!
MedallasDesbloqueadas.. %
=..& '
medallas..( 0
,..0 1!
SugerenciasEducativas// %
=//& '
sugerencias//( 3
,//3 4
AceleracionPromedio00 #
=00$ %
trayecto00& .
.00. /
AceleracionPromedio00/ B
,00B C
FrenadasFuertes11 
=11  !
trayecto11" *
.11* +
FrenadasFuertes11+ :
,11: ;
GirosBruscos22 
=22 
trayecto22 '
.22' (
GirosBruscos22( 4
,224 5
ExcesosVelocidad33  
=33! "
trayecto33# +
.33+ ,
ExcesoVelocidad33, ;
}44 
;44 
}55 	
}66 
}77 ü
WC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Normativa\NormasTransitoColombia.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
	Normativa! *
{ 
public 

static 
class "
NormasTransitoColombia .
{ 
public 
const 
double !
VelocidadMaximaUrbana 1
=2 3
$num4 8
;8 9
public 
const 
double #
AceleracionMaximaSegura 3
=4 5
$num6 9
;9 :
public 
const 
int 
MaxFrenadasFuertes +
=, -
$num. /
;/ 0
public 
const 
int 
MaxGirosBruscos (
=) *
$num+ ,
;, -
public		 
const		 
int		 
MaxExcesosVelocidad		 ,
=		- .
$num		/ 0
;		0 1
}

 
} «
SC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Normativa\EvaluadorNormativo.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
	Normativa! *
{ 
public 

static 
class 
EvaluadorNormativo *
{ 
public 
static 
bool 
CumpleNormas '
(' (
Trayecto( 0
trayecto1 9
)9 :
{		 	
return

 
trayecto

 
.

  
VelocidadPromedioKmH

 0
<=

1 3"
NormasTransitoColombia

4 J
.

J K!
VelocidadMaximaUrbana

K `
&&

a c
trayecto 
. 
AceleracionPromedio /
<=0 2"
NormasTransitoColombia3 I
.I J#
AceleracionMaximaSeguraJ a
&&b d
trayecto 
. 
FrenadasFuertes +
<=, ."
NormasTransitoColombia/ E
.E F
MaxFrenadasFuertesF X
&&Y [
trayecto 
. 
GirosBruscos (
<=) +"
NormasTransitoColombia, B
.B C
MaxGirosBruscosC R
&&S U
trayecto 
. 
ExcesoVelocidad +
<=, ."
NormasTransitoColombia/ E
.E F
MaxExcesosVelocidadF Y
;Y Z
} 	
} 
} ’
AC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\JwtService.cs
	namespace		 	
MotoSeguraAPI		
 
.		 
Services		  
{

 
public 

class 

JwtService 
{ 
private 
readonly 
IConfiguration '
_config( /
;/ 0
public 

JwtService 
( 
IConfiguration (
config) /
)/ 0
{ 	
_config 
= 
config 
; 
} 	
public 
string 
GenerateToken #
(# $
User$ (
user) -
)- .
{ 	
var 
claims 
= 
new 
[ 
] 
{ 
new 
Claim 
( 

ClaimTypes $
.$ %
NameIdentifier% 3
,3 4
user5 9
.9 :
Id: <
.< =
ToString= E
(E F
)F G
)G H
,H I
new 
Claim 
( 

ClaimTypes $
.$ %
Name% )
,) *
user+ /
./ 0
Name0 4
)4 5
,5 6
new 
Claim 
( 

ClaimTypes $
.$ %
Email% *
,* +
user, 0
.0 1
Email1 6
)6 7
} 
; 
var 
identity 
= 
new 
ClaimsIdentity -
(- .
claims. 4
,4 5
JwtBearerDefaults6 G
.G H 
AuthenticationSchemeH \
)\ ]
;] ^
var 
key 
= 
new  
SymmetricSecurityKey .
(. /
Encoding/ 7
.7 8
UTF88 <
.< =
GetBytes= E
(E F
_configF M
[M N
$strN W
]W X
!X Y
)Y Z
)Z [
;[ \
var   
creds   
=   
new   
SigningCredentials   .
(  . /
key  / 2
,  2 3
SecurityAlgorithms  4 F
.  F G

HmacSha256  G Q
)  Q R
;  R S
var"" 
tokenDescriptor"" 
=""  !
new""" %#
SecurityTokenDescriptor""& =
{## 
Subject$$ 
=$$ 
identity$$ "
,$$" #
Expires%% 
=%% 
DateTime%% "
.%%" #
UtcNow%%# )
.%%) *
AddHours%%* 2
(%%2 3
$num%%3 4
)%%4 5
,%%5 6
Issuer&& 
=&& 
_config&&  
[&&  !
$str&&! -
]&&- .
,&&. /
Audience'' 
='' 
_config'' "
[''" #
$str''# 1
]''1 2
,''2 3
SigningCredentials(( "
=((# $
creds((% *
})) 
;)) 
var++ 
tokenHandler++ 
=++ 
new++ "#
JwtSecurityTokenHandler++# :
(++: ;
)++; <
;++< =
var,, 
token,, 
=,, 
tokenHandler,, $
.,,$ %
CreateToken,,% 0
(,,0 1
tokenDescriptor,,1 @
),,@ A
;,,A B
return-- 
tokenHandler-- 
.--  

WriteToken--  *
(--* +
token--+ 0
)--0 1
;--1 2
}.. 	
}// 
}00 ¶
NC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Interfaces\IUserService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !

Interfaces! +
{ 
public 

	interface 
IUserService !
{ 
User		 
?		 
FindById		 
(		 
Guid		 
id		 
)		 
;		  
Task

 
<

 
User

 
?

 
>

 
FindByEmailAsync

 $
(

$ %
string

% +
email

, 1
)

1 2
;

2 3
bool 
Exists 
( 
Guid 
id 
) 
; 
UserProfileDto 
? 

GetProfile "
(" #
ClaimsPrincipal# 2
user3 7
)7 8
;8 9
} 
} ƒ
NC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Interfaces\IAuthService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !

Interfaces! +
{ 
public 

	interface 
IAuthService !
{ 
Task 
< 
bool 
> 
RegisterAsync  
(  !
UserRegisterDto! 0
dto1 4
)4 5
;5 6
Task		 
<		 
string		 
?		 
>		 

LoginAsync		  
(		  !
UserLoginDto		! -
dto		. 1
)		1 2
;		2 3
}

 
} Í
XC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Historial\HistorialUsuarioService.cs
	namespace		 	
MotoSeguraAPI		
 
.		 
Services		  
.		  !
	Historial		! *
{

 
public 

class #
HistorialUsuarioService (
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public #
HistorialUsuarioService &
(& ' 
ApplicationDbContext' ;
context< C
)C D
{ 	
_context 
= 
context 
; 
} 	
public 
HistorialUsuarioDto "
ObtenerHistorial# 3
(3 4
Guid4 8
userId9 ?
)? @
{ 	
var 
usuario 
= 
_context "
." #
Users# (
. 
Include 
( 
u 
=> 
u 
.  
	Trayectos  )
)) *
. 
FirstOrDefault 
(  
u  !
=>" $
u% &
.& '
Id' )
==* ,
userId- 3
)3 4
;4 5
if 
( 
usuario 
is 
null 
)  
throw 
new  
KeyNotFoundException /
(/ 0
$str0 G
)G H
;H I
var 
trayectosAnalizados #
=$ %
usuario& -
.- .
	Trayectos. 7
. 
OrderByDescending "
(" #
t# $
=>% '
t( )
.) *
FechaFin* 2
)2 3
. 
Select 
( 
t 
=> 
{   
var!! 
cumpleNormas!! $
=!!% &
EvaluadorNormativo!!' 9
.!!9 :
CumpleNormas!!: F
(!!F G
t!!G H
)!!H I
;!!I J
var"" 
medallas""  
=""! "
RecompensaService""# 4
.""4 5
EvaluarMedallas""5 D
(""D E
t""E F
,""F G
usuario""H O
)""O P
;""P Q
var## 
sugerencias## #
=##$ %
cumpleNormas##& 2
?##3 4
new##5 8
List##9 =
<##= >
string##> D
>##D E
(##E F
)##F G
:##H I%
ContenidoEducativoService##J c
.##c d
Sugerir##d k
(##k l
t##l m
)##m n
;##n o
return%% 
new%%  
TrayectoAnalizadoDto%% 3
{&& 
CumpleNormas'' $
=''% &
cumpleNormas''' 3
,''3 4!
MedallasDesbloqueadas(( -
=((. /
medallas((0 8
,((8 9!
SugerenciasEducativas)) -
=)). /
sugerencias))0 ;
,)); <
AceleracionPromedio** +
=**, -
t**. /
.**/ 0
AceleracionPromedio**0 C
,**C D
FrenadasFuertes++ '
=++( )
t++* +
.+++ ,
FrenadasFuertes++, ;
,++; <
GirosBruscos,, $
=,,% &
t,,' (
.,,( )
GirosBruscos,,) 5
,,,5 6
ExcesosVelocidad-- (
=--) *
t--+ ,
.--, -
ExcesoVelocidad--- <
}.. 
;.. 
}// 
)// 
.// 
ToList// 
(// 
)// 
;// 
return11 
new11 
HistorialUsuarioDto11 *
{22 
UserId33 
=33 
usuario33  
.33  !
Id33! #
,33# $
Nombre44 
=44 
usuario44  
.44  !
Name44! %
,44% &
	Trayectos55 
=55 
trayectosAnalizados55 /
}66 
;66 
}77 	
}88 
}99 º
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\AuthService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
{		 
public

 

class

 
AuthService

 
:

 
IAuthService

 +
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 

JwtService #
_jwt$ (
;( )
public 
AuthService 
(  
ApplicationDbContext /
context0 7
,7 8

JwtService9 C
jwtD G
)G H
{ 	
_context 
= 
context 
; 
_jwt 
= 
jwt 
; 
} 	
public 
async 
Task 
< 
bool 
> 
RegisterAsync  -
(- .
UserRegisterDto. =
dto> A
)A B
{ 	
if 
( 
await 
_context 
. 
Users $
.$ %
AnyAsync% -
(- .
u. /
=>0 2
u3 4
.4 5
Email5 :
==; =
dto> A
.A B
EmailB G
)G H
)H I
return 
false 
; 
var 
user 
= 
new 
User 
{ 
Name 
= 
dto 
. 
Name 
,  
Email 
= 
dto 
. 
Email !
,! "
PasswordHash 
= 
BCrypt %
.% &
Net& )
.) *
BCrypt* 0
.0 1
HashPassword1 =
(= >
dto> A
.A B
PasswordB J
)J K
} 
; 
_context!! 
.!! 
Users!! 
.!! 
Add!! 
(!! 
user!! #
)!!# $
;!!$ %
await"" 
_context"" 
."" 
SaveChangesAsync"" +
(""+ ,
)"", -
;""- .
return## 
true## 
;## 
}$$ 	
public&& 
async&& 
Task&& 
<&& 
string&&  
?&&  !
>&&! "

LoginAsync&&# -
(&&- .
UserLoginDto&&. :
dto&&; >
)&&> ?
{'' 	
var(( 
user(( 
=(( 
await(( 
_context(( %
.((% &
Users((& +
.((+ ,
FirstOrDefaultAsync((, ?
(((? @
u((@ A
=>((B D
u((E F
.((F G
Email((G L
==((M O
dto((P S
.((S T
Email((T Y
)((Y Z
;((Z [
if)) 
()) 
user)) 
==)) 
null)) 
||)) 
!))  !
BCrypt))! '
.))' (
Net))( +
.))+ ,
BCrypt)), 2
.))2 3
Verify))3 9
())9 :
dto)): =
.))= >
Password))> F
,))F G
user))H L
.))L M
PasswordHash))M Y
)))Y Z
)))Z [
return** 
null** 
;** 
return,, 
_jwt,, 
.,, 
GenerateToken,, %
(,,% &
user,,& *
),,* +
;,,+ ,
}-- 	
}.. 
}// Ì
YC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Analisis\AnalizadorTrayectoService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
Analisis! )
{ 
public 

static 
class %
AnalizadorTrayectoService 1
{ 
public 
static 
Trayecto 
EnriquecerTrayecto 1
(1 2
Trayecto2 :
trayecto; C
,C D
TrayectoDtoE P
dtoQ T
)T U
{		 	
trayecto 
. 
AceleracionPromedio (
=) *
CalcularAceleracion+ >
(> ?
dto? B
)B C
;C D
trayecto 
. 
FrenadasFuertes $
=% &
ContarFrenadas' 5
(5 6
dto6 9
)9 :
;: ;
trayecto 
. 
GirosBruscos !
=" #
ContarGiros$ /
(/ 0
dto0 3
)3 4
;4 5
trayecto 
. 
ExcesoVelocidad $
=% &
ContarExcesos' 4
(4 5
dto5 8
)8 9
;9 :
return 
trayecto 
; 
} 	
private 
static 
double 
CalcularAceleracion 1
(1 2
TrayectoDto2 =
dto> A
)A B
{ 	
return 
dto 
. 
Acelerometro #
.# $
Aceleracion$ /
;/ 0
} 	
private 
static 
int 
ContarFrenadas )
() *
TrayectoDto* 5
dto6 9
)9 :
{ 	
return"" 
$num"" 
;"" 
}## 	
private%% 
static%% 
int%% 
ContarGiros%% &
(%%& '
TrayectoDto%%' 2
dto%%3 6
)%%6 7
{&& 	
return(( 
$num(( 
;(( 
})) 	
private++ 
static++ 
int++ 
ContarExcesos++ (
(++( )
TrayectoDto++) 4
dto++5 8
)++8 9
{,, 	
return.. 
$num.. 
;.. 
}// 	
}00 
}11 ü	
UC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Gamificacion\RecompensaService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
Gamificacion! -
{ 
public 

static 
class 
RecompensaService )
{ 
public 
static 
List 
< 
string !
>! "
EvaluarMedallas# 2
(2 3
Trayecto3 ;
trayecto< D
,D E
UserF J
usuarioK R
)R S
{		 	
var

 
medallas

 
=

 
new

 
List

 #
<

# $
string

$ *
>

* +
(

+ ,
)

, -
;

- .
if 
( 
EvaluadorNormativo "
." #
CumpleNormas# /
(/ 0
trayecto0 8
)8 9
)9 :
medallas 
. 
Add 
( 
$str 3
)3 4
;4 5
return 
medallas 
; 
} 	
} 
} „

ZC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Services\Educacion\ContenidoEducativoService.cs
	namespace 	
MotoSeguraAPI
 
. 
Services  
.  !
	Educacion! *
{ 
public 

static 
class %
ContenidoEducativoService 1
{ 
public 
static 
List 
< 
string !
>! "
Sugerir# *
(* +
Trayecto+ 3
trayecto4 <
)< =
{ 	
var		 
sugerencias		 
=		 
new		 !
List		" &
<		& '
string		' -
>		- .
(		. /
)		/ 0
;		0 1
if 
( 
trayecto 
. 
ExcesoVelocidad (
>) *
$num+ ,
), -
sugerencias 
. 
Add 
(  
$str  N
)N O
;O P
if 
( 
trayecto 
. 
FrenadasFuertes (
>) *
$num+ ,
), -
sugerencias 
. 
Add 
(  
$str  O
)O P
;P Q
return 
sugerencias 
; 
} 	
} 
} â 
=C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\Trayecto.cs
	namespace 	
MotoSeguraAPI
 
. 
Models 
{ 
public 

class 
Trayecto 
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
FechaInicio #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
FechaFin  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
double  
DistanciaRecorridaKm *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
double  
VelocidadPromedioKmH *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
double 
VelocidadMaximaKmH (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
required 
string 
ModoConduccion -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
required 
Coordenadas #
UbicacionInicio$ 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
public 
Coordenadas 
? 
UbicacionFin (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
required 
Gps 
Gps 
{  !
get" %
;% &
set' *
;* +
}, -
public 
required 
Acelerometro $
Acelerometro% 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
required 

Giroscopio "

Giroscopio# -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
public 
required 
Conectividad $
Conectividad% 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
public 
required 
VerificacionCasco )
VerificacionCasco* ;
{< =
get> A
;A B
setC F
;F G
}H I
public 
List 
< 
Evento 
> 
Eventos #
{$ %
get& )
;) *
set+ .
;. /
}0 1
=2 3
new4 7
(7 8
)8 9
;9 :
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
=' (
null) -
!- .
;. /
public"" 
double"" 
AceleracionPromedio"" )
{""* +
get"", /
;""/ 0
set""1 4
;""4 5
}""6 7
public## 
int## 
FrenadasFuertes## "
{### $
get##% (
;##( )
set##* -
;##- .
}##/ 0
public$$ 
int$$ 
GirosBruscos$$ 
{$$  !
get$$" %
;$$% &
set$$' *
;$$* +
}$$, -
public%% 
int%% 
ExcesoVelocidad%% "
{%%# $
get%%% (
;%%( )
set%%* -
;%%- .
}%%/ 0
}&& 
}'' £S
5C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
WebHost 
. 
ConfigureKestrel  
(  !
options! (
=>) +
{ 
options 
. 
ListenAnyIP 
( 
$num 
) 
; 
options 
. 
ListenAnyIP 
( 
$num 
, 
listen $
=>% '
{ 
listen 
. 
UseHttps 
( 
$str (
,( )
$str* 4
)4 5
;5 6
} 
) 
; 
} 
) 
; 
var 
jwtKey 

= 
builder 
. 
Configuration "
[" #
$str# ,
], -
?? 
throw 
new %
InvalidOperationException *
(* +
$str+ @
)@ A
;A B
if 
( 
jwtKey 

.
 
Length 
< 
$num 
) 
throw 	
new
 %
InvalidOperationException '
(' (
$str( Q
)Q R
;R S
Console   
.   
	WriteLine   
(   
$"   
$str   6
{  6 7
jwtKey  7 =
}  = >
"  > ?
)  ? @
;  @ A
builder## 
.## 
Services## 
.## 
AddAuthentication## "
(##" #
options### *
=>##+ -
{$$ 
options%% 
.%% %
DefaultAuthenticateScheme%% %
=%%& '
JwtBearerDefaults%%( 9
.%%9 : 
AuthenticationScheme%%: N
;%%N O
options&& 
.&& "
DefaultChallengeScheme&& "
=&&# $
JwtBearerDefaults&&% 6
.&&6 7 
AuthenticationScheme&&7 K
;&&K L
}'' 
)'' 
.(( 
AddJwtBearer(( 
((( 
options(( 
=>(( 
{)) 
Console** 
.** 
	WriteLine** 
(** 
$"** 
$str** :
{**: ;
jwtKey**; A
}**A B
"**B C
)**C D
;**D E
options++ 
.++ %
TokenValidationParameters++ %
=++& '
new++( +%
TokenValidationParameters++, E
{,, 
ValidateIssuer-- 
=-- 
true-- 
,-- 
ValidateAudience.. 
=.. 
true.. 
,..  
ValidateLifetime// 
=// 
true// 
,//  $
ValidateIssuerSigningKey00  
=00! "
true00# '
,00' (
ValidIssuer11 
=11 
builder11 
.11 
Configuration11 +
[11+ ,
$str11, 8
]118 9
,119 :
ValidAudience22 
=22 
builder22 
.22  
Configuration22  -
[22- .
$str22. <
]22< =
,22= >
IssuerSigningKey33 
=33 
new33  
SymmetricSecurityKey33 3
(333 4
Encoding334 <
.33< =
UTF833= A
.33A B
GetBytes33B J
(33J K
jwtKey33K Q
)33Q R
)33R S
}44 
;44 
}55 
)55 
;55 
builder77 
.77 
Services77 
.77 
AddAuthorization77 !
(77! "
)77" #
;77# $
builder:: 
.:: 
Services:: 
.:: 
AddDbContext:: 
<::  
ApplicationDbContext:: 2
>::2 3
(::3 4
options::4 ;
=>::< >
options;; 
.;; 
	UseSqlite;; 
(;; 
$str;; 1
);;1 2
);;2 3
;;;3 4
builder>> 
.>> 
Services>> 
.>> 
AddControllers>> 
(>>  
)>>  !
;>>! "
builder?? 
.?? 
Services?? 
.?? 
AddAutoMapper?? 
(?? 
typeof?? %
(??% &
Program??& -
)??- .
)??. /
;??/ 0
builderBB 
.BB 
ServicesBB 
.BB -
!AddFluentValidationAutoValidationBB 2
(BB2 3
)BB3 4
;BB4 5
builderCC 
.CC 
ServicesCC 
.CC 1
%AddFluentValidationClientsideAdaptersCC 6
(CC6 7
)CC7 8
;CC8 9
builderDD 
.DD 
ServicesDD 
.DD /
#AddValidatorsFromAssemblyContainingDD 4
<DD4 5
TrayectoValidatorDD5 F
>DDF G
(DDG H
)DDH I
;DDI J
builderGG 
.GG 
ServicesGG 
.GG 
	AddScopedGG 
<GG 
IAuthServiceGG '
,GG' (
AuthServiceGG) 4
>GG4 5
(GG5 6
)GG6 7
;GG7 8
builderHH 
.HH 
ServicesHH 
.HH 
	AddScopedHH 
<HH 

JwtServiceHH %
>HH% &
(HH& '
)HH' (
;HH( )
builderII 
.II 
ServicesII 
.II 
	AddScopedII 
<II 
IUserServiceII '
,II' (
UserServiceII) 4
>II4 5
(II5 6
)II6 7
;II7 8
builderJJ 
.JJ 
ServicesJJ 
.JJ 
	AddScopedJJ 
<JJ #
HistorialUsuarioServiceJJ 2
>JJ2 3
(JJ3 4
)JJ4 5
;JJ5 6
builderMM 
.MM 
ServicesMM 
.MM #
AddEndpointsApiExplorerMM (
(MM( )
)MM) *
;MM* +
builderNN 
.NN 
ServicesNN 
.NN 
AddSwaggerGenNN 
(NN 
cNN  
=>NN! #
{OO 
cPP 
.PP !
AddSecurityDefinitionPP 
(PP 
$strPP $
,PP$ %
newPP& )!
OpenApiSecuritySchemePP* ?
{QQ 
DescriptionRR 
=RR 
$strRR e
,RRe f
NameSS 
=SS 
$strSS 
,SS 
InTT 

=TT 
ParameterLocationTT 
.TT 
HeaderTT %
,TT% &
TypeUU 
=UU 
SecuritySchemeTypeUU !
.UU! "
HttpUU" &
,UU& '
SchemeVV 
=VV 
$strVV 
}WW 
)WW 
;WW 
cYY 
.YY "
AddSecurityRequirementYY 
(YY 
newYY  &
OpenApiSecurityRequirementYY! ;
{ZZ 
{[[ 	
new\\ !
OpenApiSecurityScheme\\ %
{]] 
	Reference^^ 
=^^ 
new^^ 
OpenApiReference^^  0
{__ 
Type`` 
=`` 
ReferenceType`` (
.``( )
SecurityScheme``) 7
,``7 8
Idaa 
=aa 
$straa !
}bb 
}cc 
,cc 
Arraydd 
.dd 
Emptydd 
<dd 
stringdd 
>dd 
(dd  
)dd  !
}ee 	
}ff 
)ff 
;ff 
}gg 
)gg 
;gg 
builderjj 
.jj 
Servicesjj 
.jj 
AddCorsjj 
(jj 
optionsjj  
=>jj! #
{kk 
optionsll 
.ll 
	AddPolicyll 
(ll 
$strll (
,ll( )
policyll* 0
=>ll1 3
{mm 
policynn 
.nn 
WithOriginsnn 
(nn 
$strnn 5
,nn5 6
$stroo 2
,oo2 3
$strpp 5
,pp5 6
$strqq 6
)qq6 7
.rr 
AllowAnyHeaderrr 
(rr 
)rr 
.ss 
AllowAnyMethodss 
(ss 
)ss 
.tt 
AllowCredentialstt 
(tt  
)tt  !
;tt! "
}uu 
)uu 
;uu 
}vv 
)vv 
;vv 
varxx 
appxx 
=xx 	
builderxx
 
.xx 
Buildxx 
(xx 
)xx 
;xx 
app{{ 
.{{ 

UseRouting{{ 
({{ 
){{ 
;{{ 
app|| 
.|| 
UseCors|| 
(|| 
$str|| 
)|| 
;||  
app~~ 
.~~ 
UseAuthentication~~ 
(~~ 
)~~ 
;~~ 
app 
. 
UseAuthorization 
( 
) 
; 
appÅÅ 
.
ÅÅ 

UseSwagger
ÅÅ 
(
ÅÅ 
)
ÅÅ 
;
ÅÅ 
appÇÇ 
.
ÇÇ 
UseSwaggerUI
ÇÇ 
(
ÇÇ 
)
ÇÇ 
;
ÇÇ 
appÑÑ 
.
ÑÑ !
UseHttpsRedirection
ÑÑ 
(
ÑÑ 
)
ÑÑ 
;
ÑÑ 
appáá 
.
áá 
Use
áá 
(
áá 
async
áá 
(
áá 
context
áá 
,
áá 
next
áá 
)
áá 
=>
áá  
{àà 
var
ââ 

authHeader
ââ 
=
ââ 
context
ââ 
.
ââ 
Request
ââ $
.
ââ$ %
Headers
ââ% ,
[
ââ, -
$str
ââ- <
]
ââ< =
.
ââ= >
ToString
ââ> F
(
ââF G
)
ââG H
;
ââH I
Console
ää 
.
ää 
	WriteLine
ää 
(
ää 
$"
ää 
$str
ää >
{
ää> ?

authHeader
ää? I
}
ääI J
"
ääJ K
)
ääK L
;
ääL M
await
ãã 	
next
ãã
 
(
ãã 
)
ãã 
;
ãã 
}åå 
)
åå 
;
åå 
appéé 
.
éé 
MapControllers
éé 
(
éé 
)
éé 
;
éé 
awaitêê 
app
êê 	
.
êê	 

RunAsync
êê
 
(
êê 
)
êê 
;
êê ©
9C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\User.cs
	namespace 	
MotoSeguraAPI
 
. 
Models 
{ 
public 

class 
User 
{ 
[ 	
Key	 
] 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
=% &
Guid' +
.+ ,
NewGuid, 3
(3 4
)4 5
;5 6
[

 	
Required

	 
]

 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
[ 	
Required	 
] 
[ 	
EmailAddress	 
] 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
[ 	
Required	 
] 
public 
string 
PasswordHash "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
ICollection 
< 
Trayecto #
># $
	Trayectos% .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
== >
new? B
ListC G
<G H
TrayectoH P
>P Q
(Q R
)R S
;S T
} 
} ÷
PC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\VerificacionCasco.cs
	namespace 	
MotoSeguraApi
 
. 
Models 
. 
	SubModels (
{ 
public 

class 
VerificacionCasco "
{ 
public 

string 
	FotoCasco 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 

bool 
CascoDetectado 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}

 Ù
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\Gps.cs
	namespace 	
MotoSeguraApi
 
. 
Models 
. 
	SubModels (
{ 
public 

class 
Gps 
{ 
public		 
CoordenadasDto		 
	Ubicacion		 '
{		( )
get		* -
;		- .
set		/ 2
;		2 3
}		4 5
=		6 7
new		8 ;
(		; <
)		< =
;		= >
public

 
double

 
	Velocidad

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
double 
Altitud 
{ 
get  #
;# $
set% (
;( )
}* +
public 
double 
	Direccion 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} ﬁ
IC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\Giroscopio.cs
	namespace 	
MotoSeguraApi
 
. 
Models 
. 
	SubModels (
{ 
public 

class 

Giroscopio 
{ 
public 

bool !
CambioBruscoDireccion %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} Á
JC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\Coordenadas.cs
	namespace 	
MotoSeguraApi
 
. 
Models 
. 
	SubModels (
{ 
public 

class 
Coordenadas 
{ 
public 

double 
Lat 
{ 
get 
; 
set  
;  !
}" #
public 

double 
Lng 
{ 
get 
; 
set  
;  !
}" #
} 
}

 Î
KC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\Conectividad.cs
	namespace 	
MotoSeguraApi
 
. 
Models 
. 
	SubModels (
{ 
public 

class 
Conectividad 
{ 
public 

bool 
RedMovil 
{ 
get 
; 
set  #
;# $
}% &
public 

bool 
Wifi 
{ 
get 
; 
set 
;  
}! "
} 
}		 ˘
KC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\SubModels\Acelerometro.cs
	namespace 	
MotoSeguraAPI
 
. 
Models 
. 
	SubModels (
{ 
public 

class 
Acelerometro 
{ 
public 

double 
Aceleracion 
{ 
get  #
;# $
set% (
;( )
}* +
public 

bool 
FrenadoBrusco 
{ 
get  #
;# $
set% (
;( )
}* +
} 
}

 √
;C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\Evento.cs
	namespace 	
MotoSeguraAPI
 
. 
Models 
{ 
public 

class 
Evento 
{ 
[ 	
Key	 
] 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
[ 	
Required	 
] 
public 
string 
Tipo 
{ 
get  
;  !
set" %
;% &
}' (
=) *
string+ 1
.1 2
Empty2 7
;7 8
public 
string 
? 
Detalles 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
] 
public 
DateTime 
	Timestamp !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	

ForeignKey	 
( 
$str 
) 
]  
public 
Guid 

TrayectoId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Trayecto 
Trayecto  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
} 
} î
=C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Models\EventLog.cs
	namespace 	
MotoSeguraAPI
 
. 
Models 
{ 
public 

class 
EventLog 
{ 
[ 	
Key	 
] 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
=		% &
Guid		' +
.		+ ,
NewGuid		, 3
(		3 4
)		4 5
;		5 6
[

 	
Required

	 
]

 
public 
DateTime 
	Timestamp !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
] 
public 
string 
? 
Description "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public	 
User 
? 
User 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ç!
\C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251110212706_AddUniqueEmailToUser.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public 

partial 
class  
AddUniqueEmailToUser -
:. /
	Migration0 9
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str $
,$ %
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
migrationBuilder 
. 
AlterColumn (
<( )
double) /
>/ 0
(0 1
name 
: 
$str )
,) *
table 
: 
$str "
," #
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num !
,! "

oldClrType 
: 
typeof "
(" #
double# )
)) *
,* +
oldType 
: 
$str 
,  
oldNullable 
: 
true !
)! "
;" #
migrationBuilder 
. 
AlterColumn (
<( )
double) /
>/ 0
(0 1
name 
: 
$str )
,) *
table   
:   
$str   "
,  " #
type!! 
:!! 
$str!! 
,!! 
nullable"" 
:"" 
false"" 
,""  
defaultValue## 
:## 
$num## !
,##! "

oldClrType$$ 
:$$ 
typeof$$ "
($$" #
double$$# )
)$$) *
,$$* +
oldType%% 
:%% 
$str%% 
,%%  
oldNullable&& 
:&& 
true&& !
)&&! "
;&&" #
}'' 	
	protected** 
override** 
void** 
Down**  $
(**$ %
MigrationBuilder**% 5
migrationBuilder**6 F
)**F G
{++ 	
migrationBuilder,, 
.,, 

DropColumn,, '
(,,' (
name-- 
:-- 
$str-- $
,--$ %
table.. 
:.. 
$str.. 
).. 
;..  
migrationBuilder00 
.00 
AlterColumn00 (
<00( )
double00) /
>00/ 0
(000 1
name11 
:11 
$str11 )
,11) *
table22 
:22 
$str22 "
,22" #
type33 
:33 
$str33 
,33 
nullable44 
:44 
true44 
,44 

oldClrType55 
:55 
typeof55 "
(55" #
double55# )
)55) *
,55* +
oldType66 
:66 
$str66 
)66  
;66  !
migrationBuilder88 
.88 
AlterColumn88 (
<88( )
double88) /
>88/ 0
(880 1
name99 
:99 
$str99 )
,99) *
table:: 
::: 
$str:: "
,::" #
type;; 
:;; 
$str;; 
,;; 
nullable<< 
:<< 
true<< 
,<< 

oldClrType== 
:== 
typeof== "
(==" #
double==# )
)==) *
,==* +
oldType>> 
:>> 
$str>> 
)>>  
;>>  !
}?? 	
}@@ 
}AA —
[C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251110194714_UpdateTrayectoModel.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public		 

partial		 
class		 
UpdateTrayectoModel		 ,
:		- .
	Migration		/ 8
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
DropForeignKey +
(+ ,
name 
: 
$str 8
,8 9
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 
	DropIndex &
(& '
name 
: 
$str .
,. /
table 
: 
$str  
)  !
;! "
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str #
,# $
table 
: 
$str  
)  !
;! "
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
Guid' +
>+ ,
(, -
name 
: 
$str #
,# $
table   
:   
$str    
,    !
type!! 
:!! 
$str!! 
,!! 
nullable"" 
:"" 
false"" 
,""  
defaultValue## 
:## 
new## !
Guid##" &
(##& '
$str##' M
)##M N
)##N O
;##O P
migrationBuilder%% 
.%% 
CreateIndex%% (
(%%( )
name&& 
:&& 
$str&& .
,&&. /
table'' 
:'' 
$str''  
,''  !
column(( 
:(( 
$str(( %
)((% &
;((& '
migrationBuilder** 
.** 
AddForeignKey** *
(*** +
name++ 
:++ 
$str++ 8
,++8 9
table,, 
:,, 
$str,,  
,,,  !
column-- 
:-- 
$str-- %
,--% &
principalTable.. 
:.. 
$str..  +
,..+ ,
principalColumn// 
://  
$str//! %
,//% &
onDelete00 
:00 
ReferentialAction00 +
.00+ ,
Cascade00, 3
)003 4
;004 5
}11 	
}22 
}33 ¿ì
XC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251110193049_AddTrayectoModel.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public		 

partial		 
class		 
AddTrayectoModel		 )
:		* +
	Migration		, 5
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str !
)! "
;" #
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str '
,' (
table 
: 
$str 
) 
;  
migrationBuilder 
. 
RenameColumn )
() *
name 
: 
$str "
," #
table 
: 
$str 
, 
newName 
: 
$str  
)  !
;! "
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str !
,! "
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 8
,8 9
nullable: B
:B C
falseD I
)I J
,J K
FechaInicio 
=  !
table" '
.' (
Column( .
<. /
DateTime/ 7
>7 8
(8 9
type9 =
:= >
$str? E
,E F
nullableG O
:O P
falseQ V
)V W
,W X
FechaFin   
=   
table   $
.  $ %
Column  % +
<  + ,
DateTime  , 4
>  4 5
(  5 6
type  6 :
:  : ;
$str  < B
,  B C
nullable  D L
:  L M
false  N S
)  S T
,  T U 
DistanciaRecorridaKm!! (
=!!) *
table!!+ 0
.!!0 1
Column!!1 7
<!!7 8
double!!8 >
>!!> ?
(!!? @
type!!@ D
:!!D E
$str!!F L
,!!L M
nullable!!N V
:!!V W
false!!X ]
)!!] ^
,!!^ _ 
VelocidadPromedioKmH"" (
="") *
table""+ 0
.""0 1
Column""1 7
<""7 8
double""8 >
>""> ?
(""? @
type""@ D
:""D E
$str""F L
,""L M
nullable""N V
:""V W
false""X ]
)""] ^
,""^ _
VelocidadMaximaKmH## &
=##' (
table##) .
.##. /
Column##/ 5
<##5 6
double##6 <
>##< =
(##= >
type##> B
:##B C
$str##D J
,##J K
nullable##L T
:##T U
false##V [
)##[ \
,##\ ]
ModoConduccion$$ "
=$$# $
table$$% *
.$$* +
Column$$+ 1
<$$1 2
string$$2 8
>$$8 9
($$9 :
type$$: >
:$$> ?
$str$$@ F
,$$F G
nullable$$H P
:$$P Q
false$$R W
)$$W X
,$$X Y
UbicacionInicio_Lat%% '
=%%( )
table%%* /
.%%/ 0
Column%%0 6
<%%6 7
double%%7 =
>%%= >
(%%> ?
type%%? C
:%%C D
$str%%E K
,%%K L
nullable%%M U
:%%U V
false%%W \
)%%\ ]
,%%] ^
UbicacionInicio_Lng&& '
=&&( )
table&&* /
.&&/ 0
Column&&0 6
<&&6 7
double&&7 =
>&&= >
(&&> ?
type&&? C
:&&C D
$str&&E K
,&&K L
nullable&&M U
:&&U V
false&&W \
)&&\ ]
,&&] ^
UbicacionFin_Lat'' $
=''% &
table''' ,
.'', -
Column''- 3
<''3 4
double''4 :
>'': ;
(''; <
type''< @
:''@ A
$str''B H
,''H I
nullable''J R
:''R S
true''T X
)''X Y
,''Y Z
UbicacionFin_Lng(( $
=((% &
table((' ,
.((, -
Column((- 3
<((3 4
double((4 :
>((: ;
(((; <
type((< @
:((@ A
$str((B H
,((H I
nullable((J R
:((R S
true((T X
)((X Y
,((Y Z
Gps_Ubicacion_Lat)) %
=))& '
table))( -
.))- .
Column)). 4
<))4 5
double))5 ;
>)); <
())< =
type))= A
:))A B
$str))C I
,))I J
nullable))K S
:))S T
true))U Y
)))Y Z
,))Z [
Gps_Ubicacion_Lng** %
=**& '
table**( -
.**- .
Column**. 4
<**4 5
double**5 ;
>**; <
(**< =
type**= A
:**A B
$str**C I
,**I J
nullable**K S
:**S T
true**U Y
)**Y Z
,**Z [
Gps_Velocidad++ !
=++" #
table++$ )
.++) *
Column++* 0
<++0 1
double++1 7
>++7 8
(++8 9
type++9 =
:++= >
$str++? E
,++E F
nullable++G O
:++O P
false++Q V
)++V W
,++W X
Gps_Altitud,, 
=,,  !
table,," '
.,,' (
Column,,( .
<,,. /
double,,/ 5
>,,5 6
(,,6 7
type,,7 ;
:,,; <
$str,,= C
,,,C D
nullable,,E M
:,,M N
false,,O T
),,T U
,,,U V
Gps_Direccion-- !
=--" #
table--$ )
.--) *
Column--* 0
<--0 1
double--1 7
>--7 8
(--8 9
type--9 =
:--= >
$str--? E
,--E F
nullable--G O
:--O P
false--Q V
)--V W
,--W X$
Acelerometro_Aceleracion.. ,
=..- .
table../ 4
...4 5
Column..5 ;
<..; <
double..< B
>..B C
(..C D
type..D H
:..H I
$str..J P
,..P Q
nullable..R Z
:..Z [
false..\ a
)..a b
,..b c&
Acelerometro_FrenadoBrusco// .
=/// 0
table//1 6
.//6 7
Column//7 =
<//= >
bool//> B
>//B C
(//C D
type//D H
://H I
$str//J S
,//S T
nullable//U ]
://] ^
false//_ d
)//d e
,//e f,
 Giroscopio_CambioBruscoDireccion00 4
=005 6
table007 <
.00< =
Column00= C
<00C D
bool00D H
>00H I
(00I J
type00J N
:00N O
$str00P Y
,00Y Z
nullable00[ c
:00c d
false00e j
)00j k
,00k l!
Conectividad_RedMovil11 )
=11* +
table11, 1
.111 2
Column112 8
<118 9
bool119 =
>11= >
(11> ?
type11? C
:11C D
$str11E N
,11N O
nullable11P X
:11X Y
false11Z _
)11_ `
,11` a
Conectividad_Wifi22 %
=22& '
table22( -
.22- .
Column22. 4
<224 5
bool225 9
>229 :
(22: ;
type22; ?
:22? @
$str22A J
,22J K
nullable22L T
:22T U
false22V [
)22[ \
,22\ ]'
VerificacionCasco_FotoCasco33 /
=330 1
table332 7
.337 8
Column338 >
<33> ?
string33? E
>33E F
(33F G
type33G K
:33K L
$str33M S
,33S T
nullable33U ]
:33] ^
false33_ d
)33d e
,33e f,
 VerificacionCasco_CascoDetectado44 4
=445 6
table447 <
.44< =
Column44= C
<44C D
bool44D H
>44H I
(44I J
type44J N
:44N O
$str44P Y
,44Y Z
nullable44[ c
:44c d
false44e j
)44j k
,44k l
UserId55 
=55 
table55 "
.55" #
Column55# )
<55) *
Guid55* .
>55. /
(55/ 0
type550 4
:554 5
$str556 <
,55< =
nullable55> F
:55F G
false55H M
)55M N
}66 
,66 
constraints77 
:77 
table77 "
=>77# %
{88 
table99 
.99 

PrimaryKey99 $
(99$ %
$str99% 3
,993 4
x995 6
=>997 9
x99: ;
.99; <
Id99< >
)99> ?
;99? @
table:: 
.:: 

ForeignKey:: $
(::$ %
name;; 
:;; 
$str;; 9
,;;9 :
column<< 
:<< 
x<<  !
=><<" $
x<<% &
.<<& '
UserId<<' -
,<<- .
principalTable== &
:==& '
$str==( /
,==/ 0
principalColumn>> '
:>>' (
$str>>) -
,>>- .
onDelete??  
:??  !
ReferentialAction??" 3
.??3 4
Cascade??4 ;
)??; <
;??< =
}@@ 
)@@ 
;@@ 
migrationBuilderBB 
.BB 
CreateTableBB (
(BB( )
nameCC 
:CC 
$strCC 
,CC  
columnsDD 
:DD 
tableDD 
=>DD !
newDD" %
{EE 
IdFF 
=FF 
tableFF 
.FF 
ColumnFF %
<FF% &
GuidFF& *
>FF* +
(FF+ ,
typeFF, 0
:FF0 1
$strFF2 8
,FF8 9
nullableFF: B
:FFB C
falseFFD I
)FFI J
,FFJ K
TipoGG 
=GG 
tableGG  
.GG  !
ColumnGG! '
<GG' (
stringGG( .
>GG. /
(GG/ 0
typeGG0 4
:GG4 5
$strGG6 <
,GG< =
nullableGG> F
:GGF G
falseGGH M
)GGM N
,GGN O
DetallesHH 
=HH 
tableHH $
.HH$ %
ColumnHH% +
<HH+ ,
stringHH, 2
>HH2 3
(HH3 4
typeHH4 8
:HH8 9
$strHH: @
,HH@ A
nullableHHB J
:HHJ K
trueHHL P
)HHP Q
,HHQ R
	TimestampII 
=II 
tableII  %
.II% &
ColumnII& ,
<II, -
DateTimeII- 5
>II5 6
(II6 7
typeII7 ;
:II; <
$strII= C
,IIC D
nullableIIE M
:IIM N
falseIIO T
)IIT U
,IIU V

TrayectoIdJJ 
=JJ  
tableJJ! &
.JJ& '
ColumnJJ' -
<JJ- .
GuidJJ. 2
>JJ2 3
(JJ3 4
typeJJ4 8
:JJ8 9
$strJJ: @
,JJ@ A
nullableJJB J
:JJJ K
falseJJL Q
)JJQ R
,JJR S
TrayectoId1KK 
=KK  !
tableKK" '
.KK' (
ColumnKK( .
<KK. /
GuidKK/ 3
>KK3 4
(KK4 5
typeKK5 9
:KK9 :
$strKK; A
,KKA B
nullableKKC K
:KKK L
falseKKM R
)KKR S
}LL 
,LL 
constraintsMM 
:MM 
tableMM "
=>MM# %
{NN 
tableOO 
.OO 

PrimaryKeyOO $
(OO$ %
$strOO% 1
,OO1 2
xOO3 4
=>OO5 7
xOO8 9
.OO9 :
IdOO: <
)OO< =
;OO= >
tablePP 
.PP 

ForeignKeyPP $
(PP$ %
nameQQ 
:QQ 
$strQQ ?
,QQ? @
columnRR 
:RR 
xRR  !
=>RR" $
xRR% &
.RR& '

TrayectoIdRR' 1
,RR1 2
principalTableSS &
:SS& '
$strSS( 3
,SS3 4
principalColumnTT '
:TT' (
$strTT) -
,TT- .
onDeleteUU  
:UU  !
ReferentialActionUU" 3
.UU3 4
CascadeUU4 ;
)UU; <
;UU< =
tableVV 
.VV 

ForeignKeyVV $
(VV$ %
nameWW 
:WW 
$strWW @
,WW@ A
columnXX 
:XX 
xXX  !
=>XX" $
xXX% &
.XX& '
TrayectoId1XX' 2
,XX2 3
principalTableYY &
:YY& '
$strYY( 3
,YY3 4
principalColumnZZ '
:ZZ' (
$strZZ) -
,ZZ- .
onDelete[[  
:[[  !
ReferentialAction[[" 3
.[[3 4
Cascade[[4 ;
)[[; <
;[[< =
}\\ 
)\\ 
;\\ 
migrationBuilder^^ 
.^^ 
CreateIndex^^ (
(^^( )
name__ 
:__ 
$str__ -
,__- .
table`` 
:`` 
$str``  
,``  !
columnaa 
:aa 
$straa $
)aa$ %
;aa% &
migrationBuildercc 
.cc 
CreateIndexcc (
(cc( )
namedd 
:dd 
$strdd .
,dd. /
tableee 
:ee 
$stree  
,ee  !
columnff 
:ff 
$strff %
)ff% &
;ff& '
migrationBuilderhh 
.hh 
CreateIndexhh (
(hh( )
nameii 
:ii 
$strii +
,ii+ ,
tablejj 
:jj 
$strjj "
,jj" #
columnkk 
:kk 
$strkk  
)kk  !
;kk! "
}ll 	
	protectedoo 
overrideoo 
voidoo 
Downoo  $
(oo$ %
MigrationBuilderoo% 5
migrationBuilderoo6 F
)ooF G
{pp 	
migrationBuilderqq 
.qq 
	DropTableqq &
(qq& '
namerr 
:rr 
$strrr 
)rr  
;rr  !
migrationBuildertt 
.tt 
	DropTablett &
(tt& '
nameuu 
:uu 
$struu !
)uu! "
;uu" #
migrationBuilderww 
.ww 
RenameColumnww )
(ww) *
namexx 
:xx 
$strxx 
,xx 
tableyy 
:yy 
$stryy 
,yy 
newNamezz 
:zz 
$strzz %
)zz% &
;zz& '
migrationBuilder|| 
.|| 
	AddColumn|| &
<||& '
bool||' +
>||+ ,
(||, -
name}} 
:}} 
$str}} '
,}}' (
table~~ 
:~~ 
$str~~ 
,~~ 
type 
: 
$str 
,  
nullable
ÄÄ 
:
ÄÄ 
false
ÄÄ 
,
ÄÄ  
defaultValue
ÅÅ 
:
ÅÅ 
false
ÅÅ #
)
ÅÅ# $
;
ÅÅ$ %
migrationBuilder
ÉÉ 
.
ÉÉ 
CreateTable
ÉÉ (
(
ÉÉ( )
name
ÑÑ 
:
ÑÑ 
$str
ÑÑ !
,
ÑÑ! "
columns
ÖÖ 
:
ÖÖ 
table
ÖÖ 
=>
ÖÖ !
new
ÖÖ" %
{
ÜÜ 
Id
áá 
=
áá 
table
áá 
.
áá 
Column
áá %
<
áá% &
Guid
áá& *
>
áá* +
(
áá+ ,
type
áá, 0
:
áá0 1
$str
áá2 8
,
áá8 9
nullable
áá: B
:
ááB C
false
ááD I
)
ááI J
,
ááJ K
UserId
àà 
=
àà 
table
àà "
.
àà" #
Column
àà# )
<
àà) *
Guid
àà* .
>
àà. /
(
àà/ 0
type
àà0 4
:
àà4 5
$str
àà6 <
,
àà< =
nullable
àà> F
:
ààF G
false
ààH M
)
ààM N
,
ààN O
Description
ââ 
=
ââ  !
table
ââ" '
.
ââ' (
Column
ââ( .
<
ââ. /
string
ââ/ 5
>
ââ5 6
(
ââ6 7
type
ââ7 ;
:
ââ; <
$str
ââ= C
,
ââC D
nullable
ââE M
:
ââM N
false
ââO T
)
ââT U
,
ââU V
	Timestamp
ää 
=
ää 
table
ää  %
.
ää% &
Column
ää& ,
<
ää, -
DateTime
ää- 5
>
ää5 6
(
ää6 7
type
ää7 ;
:
ää; <
$str
ää= C
,
ääC D
nullable
ääE M
:
ääM N
false
ääO T
)
ääT U
}
ãã 
,
ãã 
constraints
åå 
:
åå 
table
åå "
=>
åå# %
{
çç 
table
éé 
.
éé 

PrimaryKey
éé $
(
éé$ %
$str
éé% 3
,
éé3 4
x
éé5 6
=>
éé7 9
x
éé: ;
.
éé; <
Id
éé< >
)
éé> ?
;
éé? @
table
èè 
.
èè 

ForeignKey
èè $
(
èè$ %
name
êê 
:
êê 
$str
êê 9
,
êê9 :
column
ëë 
:
ëë 
x
ëë  !
=>
ëë" $
x
ëë% &
.
ëë& '
UserId
ëë' -
,
ëë- .
principalTable
íí &
:
íí& '
$str
íí( /
,
íí/ 0
principalColumn
ìì '
:
ìì' (
$str
ìì) -
,
ìì- .
onDelete
îî  
:
îî  !
ReferentialAction
îî" 3
.
îî3 4
Cascade
îî4 ;
)
îî; <
;
îî< =
}
ïï 
)
ïï 
;
ïï 
migrationBuilder
óó 
.
óó 
CreateIndex
óó (
(
óó( )
name
òò 
:
òò 
$str
òò +
,
òò+ ,
table
ôô 
:
ôô 
$str
ôô "
,
ôô" #
column
öö 
:
öö 
$str
öö  
)
öö  !
;
öö! "
}
õõ 	
}
úú 
}ùù é
UC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251105233222_InitialCreate.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public 

partial 
class 
InitialCreate &
:' (
	Migration) 2
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
string) /
>/ 0
(0 1
name 
: 
$str #
,# $
table 
: 
$str "
," #
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$str  
,  !

oldClrType 
: 
typeof "
(" #
string# )
)) *
,* +
oldType 
: 
$str 
,  
oldNullable 
: 
true !
)! "
;" #
migrationBuilder 
. 
CreateIndex (
(( )
name 
: 
$str +
,+ ,
table 
: 
$str "
," #
column 
: 
$str  
)  !
;! "
migrationBuilder 
. 
AddForeignKey *
(* +
name 
: 
$str 1
,1 2
table 
: 
$str "
," #
column 
: 
$str  
,  !
principalTable   
:   
$str    '
,  ' (
principalColumn!! 
:!!  
$str!!! %
,!!% &
onDelete"" 
:"" 
ReferentialAction"" +
.""+ ,
Cascade"", 3
)""3 4
;""4 5
}## 	
	protected&& 
override&& 
void&& 
Down&&  $
(&&$ %
MigrationBuilder&&% 5
migrationBuilder&&6 F
)&&F G
{'' 	
migrationBuilder(( 
.(( 
DropForeignKey(( +
(((+ ,
name)) 
:)) 
$str)) 1
,))1 2
table** 
:** 
$str** "
)**" #
;**# $
migrationBuilder,, 
.,, 
	DropIndex,, &
(,,& '
name-- 
:-- 
$str-- +
,--+ ,
table.. 
:.. 
$str.. "
).." #
;..# $
migrationBuilder00 
.00 
AlterColumn00 (
<00( )
string00) /
>00/ 0
(000 1
name11 
:11 
$str11 #
,11# $
table22 
:22 
$str22 "
,22" #
type33 
:33 
$str33 
,33 
nullable44 
:44 
true44 
,44 

oldClrType55 
:55 
typeof55 "
(55" #
string55# )
)55) *
,55* +
oldType66 
:66 
$str66 
)66  
;66  !
}77 	
}88 
}99 ˘;
iC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251105230923_UpdateModelsWithGuidAndValidation.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public		 

partial		 
class		 -
!UpdateModelsWithGuidAndValidation		 :
:		; <
	Migration		= F
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
AlterColumn (
<( )
string) /
>/ 0
(0 1
name 
: 
$str 
, 
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$str  
,  !

oldClrType 
: 
typeof "
(" #
string# )
)) *
,* +
oldType 
: 
$str 
,  
oldNullable 
: 
true !
)! "
;" #
migrationBuilder 
. 
AlterColumn (
<( )
string) /
>/ 0
(0 1
name 
: 
$str "
," #
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$str  
,  !

oldClrType 
: 
typeof "
(" #
string# )
)) *
,* +
oldType 
: 
$str 
,  
oldNullable   
:   
true   !
)  ! "
;  " #
migrationBuilder"" 
."" 
AlterColumn"" (
<""( )
Guid"") -
>""- .
("". /
name## 
:## 
$str## 
,## 
table$$ 
:$$ 
$str$$ 
,$$ 
type%% 
:%% 
$str%% 
,%% 
nullable&& 
:&& 
false&& 
,&&  

oldClrType'' 
:'' 
typeof'' "
(''" #
int''# &
)''& '
,''' (
oldType(( 
:(( 
$str(( "
)((" #
.)) 
OldAnnotation)) 
()) 
$str)) 5
,))5 6
true))7 ;
))); <
;))< =
migrationBuilder++ 
.++ 
AlterColumn++ (
<++( )
Guid++) -
>++- .
(++. /
name,, 
:,, 
$str,, 
,,, 
table-- 
:-- 
$str-- "
,--" #
type.. 
:.. 
$str.. 
,.. 
nullable// 
:// 
false// 
,//  

oldClrType00 
:00 
typeof00 "
(00" #
int00# &
)00& '
,00' (
oldType11 
:11 
$str11 "
)11" #
;11# $
migrationBuilder33 
.33 
AlterColumn33 (
<33( )
Guid33) -
>33- .
(33. /
name44 
:44 
$str44 
,44 
table55 
:55 
$str55 "
,55" #
type66 
:66 
$str66 
,66 
nullable77 
:77 
false77 
,77  

oldClrType88 
:88 
typeof88 "
(88" #
int88# &
)88& '
,88' (
oldType99 
:99 
$str99 "
)99" #
.:: 
OldAnnotation:: 
(:: 
$str:: 5
,::5 6
true::7 ;
)::; <
;::< =
};; 	
	protected>> 
override>> 
void>> 
Down>>  $
(>>$ %
MigrationBuilder>>% 5
migrationBuilder>>6 F
)>>F G
{?? 	
migrationBuilder@@ 
.@@ 
AlterColumn@@ (
<@@( )
string@@) /
>@@/ 0
(@@0 1
nameAA 
:AA 
$strAA 
,AA 
tableBB 
:BB 
$strBB 
,BB 
typeCC 
:CC 
$strCC 
,CC 
nullableDD 
:DD 
trueDD 
,DD 

oldClrTypeEE 
:EE 
typeofEE "
(EE" #
stringEE# )
)EE) *
,EE* +
oldTypeFF 
:FF 
$strFF 
)FF  
;FF  !
migrationBuilderHH 
.HH 
AlterColumnHH (
<HH( )
stringHH) /
>HH/ 0
(HH0 1
nameII 
:II 
$strII "
,II" #
tableJJ 
:JJ 
$strJJ 
,JJ 
typeKK 
:KK 
$strKK 
,KK 
nullableLL 
:LL 
trueLL 
,LL 

oldClrTypeMM 
:MM 
typeofMM "
(MM" #
stringMM# )
)MM) *
,MM* +
oldTypeNN 
:NN 
$strNN 
)NN  
;NN  !
migrationBuilderPP 
.PP 
AlterColumnPP (
<PP( )
intPP) ,
>PP, -
(PP- .
nameQQ 
:QQ 
$strQQ 
,QQ 
tableRR 
:RR 
$strRR 
,RR 
typeSS 
:SS 
$strSS 
,SS  
nullableTT 
:TT 
falseTT 
,TT  

oldClrTypeUU 
:UU 
typeofUU "
(UU" #
GuidUU# '
)UU' (
,UU( )
oldTypeVV 
:VV 
$strVV 
)VV  
.WW 

AnnotationWW 
(WW 
$strWW 2
,WW2 3
trueWW4 8
)WW8 9
;WW9 :
migrationBuilderYY 
.YY 
AlterColumnYY (
<YY( )
intYY) ,
>YY, -
(YY- .
nameZZ 
:ZZ 
$strZZ 
,ZZ 
table[[ 
:[[ 
$str[[ "
,[[" #
type\\ 
:\\ 
$str\\ 
,\\  
nullable]] 
:]] 
false]] 
,]]  

oldClrType^^ 
:^^ 
typeof^^ "
(^^" #
Guid^^# '
)^^' (
,^^( )
oldType__ 
:__ 
$str__ 
)__  
;__  !
migrationBuilderaa 
.aa 
AlterColumnaa (
<aa( )
intaa) ,
>aa, -
(aa- .
namebb 
:bb 
$strbb 
,bb 
tablecc 
:cc 
$strcc "
,cc" #
typedd 
:dd 
$strdd 
,dd  
nullableee 
:ee 
falseee 
,ee  

oldClrTypeff 
:ff 
typeofff "
(ff" #
Guidff# '
)ff' (
,ff( )
oldTypegg 
:gg 
$strgg 
)gg  
.hh 

Annotationhh 
(hh 
$strhh 2
,hh2 3
truehh4 8
)hh8 9
;hh9 :
}ii 	
}jj 
}kk à'
SC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Migrations\20251105225223_GuidSupport.cs
	namespace 	
MotoSeguraAPI
 
. 

Migrations "
{ 
public		 

partial		 
class		 
GuidSupport		 $
:		% &
	Migration		' 0
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str !
,! "
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
int& )
>) *
(* +
type+ /
:/ 0
$str1 :
,: ;
nullable< D
:D E
falseF K
)K L
. 

Annotation #
(# $
$str$ :
,: ;
true< @
)@ A
,A B
	Timestamp 
= 
table  %
.% &
Column& ,
<, -
DateTime- 5
>5 6
(6 7
type7 ;
:; <
$str= C
,C D
nullableE M
:M N
falseO T
)T U
,U V
Description 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= C
,C D
nullableE M
:M N
trueO S
)S T
,T U
UserId 
= 
table "
." #
Column# )
<) *
int* -
>- .
(. /
type/ 3
:3 4
$str5 >
,> ?
nullable@ H
:H I
falseJ O
)O P
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 3
,3 4
x5 6
=>7 9
x: ;
.; <
Id< >
)> ?
;? @
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str 
, 
columns 
: 
table 
=> !
new" %
{   
Id!! 
=!! 
table!! 
.!! 
Column!! %
<!!% &
int!!& )
>!!) *
(!!* +
type!!+ /
:!!/ 0
$str!!1 :
,!!: ;
nullable!!< D
:!!D E
false!!F K
)!!K L
."" 

Annotation"" #
(""# $
$str""$ :
,"": ;
true""< @
)""@ A
,""A B
Name## 
=## 
table##  
.##  !
Column##! '
<##' (
string##( .
>##. /
(##/ 0
type##0 4
:##4 5
$str##6 <
,##< =
nullable##> F
:##F G
true##H L
)##L M
,##M N

HelmetType$$ 
=$$  
table$$! &
.$$& '
Column$$' -
<$$- .
string$$. 4
>$$4 5
($$5 6
type$$6 :
:$$: ;
$str$$< B
,$$B C
nullable$$D L
:$$L M
true$$N R
)$$R S
,$$S T
HelmetValidated%% #
=%%$ %
table%%& +
.%%+ ,
Column%%, 2
<%%2 3
bool%%3 7
>%%7 8
(%%8 9
type%%9 =
:%%= >
$str%%? H
,%%H I
nullable%%J R
:%%R S
false%%T Y
)%%Y Z
}&& 
,&& 
constraints'' 
:'' 
table'' "
=>''# %
{(( 
table)) 
.)) 

PrimaryKey)) $
())$ %
$str))% /
,))/ 0
x))1 2
=>))3 5
x))6 7
.))7 8
Id))8 :
))): ;
;)); <
}** 
)** 
;** 
}++ 	
	protected.. 
override.. 
void.. 
Down..  $
(..$ %
MigrationBuilder..% 5
migrationBuilder..6 F
)..F G
{// 	
migrationBuilder00 
.00 
	DropTable00 &
(00& '
name11 
:11 
$str11 !
)11! "
;11" #
migrationBuilder33 
.33 
	DropTable33 &
(33& '
name44 
:44 
$str44 
)44 
;44 
}55 	
}66 
}77 —
FC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Mappings\TrayectoProfile.cs
	namespace 	
MotoSeguraAPI
 
. 
Mappings  
{		 
public

 

class

 
TrayectoProfile

  
:

! "
Profile

# *
{ 
public 
TrayectoProfile 
( 
)  
{ 	
	CreateMap 
< 
TrayectoDto !
,! "
Trayecto# +
>+ ,
(, -
)- .
;. /
	CreateMap 
< 
CoordenadasDto $
,$ %
Coordenadas& 1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< 
GpsDto 
, 
Gps !
>! "
(" #
)# $
;$ %
	CreateMap 
< 
AcelerometroDto %
,% &
Acelerometro' 3
>3 4
(4 5
)5 6
;6 7
	CreateMap 
< 
GiroscopioDto #
,# $

Giroscopio% /
>/ 0
(0 1
)1 2
;2 3
	CreateMap 
< 
ConectividadDto %
,% &
Conectividad' 3
>3 4
(4 5
)5 6
;6 7
	CreateMap 
<  
VerificacionCascoDto *
,* +
VerificacionCasco, =
>= >
(> ?
)? @
;@ A
	CreateMap 
< 
EventoDetectadoDto (
,( )
Evento* 0
>0 1
(1 2
)2 3
;3 4
} 	
} 
} ©
GC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\VerificacionCascoDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class  
VerificacionCascoDto %
{ 
public 

string 
	FotoCasco 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 

bool 
Casco_Detectado 
{  !
get" %
;% &
set' *
;* +
}, -
} 
}		 Æ	
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\UserRegisterDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
UserRegisterDto  
{ 
[ 	
Required	 
] 
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
string		+ 1
.		1 2
Empty		2 7
;		7 8
[ 	
EmailAddress	 
] 
[ 	
Required	 
] 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
[ 	
Required	 
] 
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
} ÿ
AC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\UserProfileDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
UserProfileDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
default+ 2
!2 3
;3 4
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
default, 3
!3 4
;4 5
} 
}		 ä
?C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\UserLoginDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
UserLoginDto 
{ 
[ 	
Required	 
] 
[		 	
EmailAddress			 
]		 
public

 
string

 
Email

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
string

, 2
.

2 3
Empty

3 8
;

8 9
[ 	
Required	 
] 
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
} ä
GC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\TrayectoAnalizadoDto.cs
	namespace 	
MotoSeguraAPI
 
. 
Dtos 
{ 
public 

class  
TrayectoAnalizadoDto %
{ 
public 
bool 
CumpleNormas  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
List 
< 
string 
> !
MedallasDesbloqueadas 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
=@ A
newB E
(E F
)F G
;G H
public 
List 
< 
string 
> !
SugerenciasEducativas 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
=@ A
newB E
(E F
)F G
;G H
public 
double 
AceleracionPromedio )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public		 
int		 
FrenadasFuertes		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
public

 
int

 
GirosBruscos

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
int 
ExcesosVelocidad #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} …
>C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\TrayectoDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
TrayectoDto 
{ 
public 
DateTime 
FechaInicio #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DateTime 
FechaFin  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
double  
DistanciaRecorridaKm *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
double  
VelocidadPromedioKmH *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
double 
VelocidadMaximaKmH (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
ModoConduccion $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
string5 ;
.; <
Empty< A
;A B
public 
CoordenadasDto 
UbicacionInicio -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
=< =
new> A
(A B
)B C
;C D
public 
CoordenadasDto 
? 
UbicacionFin +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
GpsDto 
Gps 
{ 
get 
;  
set! $
;$ %
}& '
=( )
new* -
(- .
). /
;/ 0
public 
AcelerometroDto 
Acelerometro +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
=: ;
new< ?
(? @
)@ A
;A B
public 
GiroscopioDto 

Giroscopio '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
new8 ;
(; <
)< =
;= >
public 
ConectividadDto 
Conectividad +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
=: ;
new< ?
(? @
)@ A
;A B
public 
List 
< 
EventoDetectadoDto &
>& '
Eventos( /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
=> ?
new@ C
(C D
)D E
;E F
public  
VerificacionCascoDto #
VerificacionCasco$ 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
=D E
newF I
(I J
)J K
;K L
} 
} ´
CC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\StartBikeRequest.cs
	namespace 	
MotoSeguraAPI
 
. 
DTOs 
{ 
public 

class 
StartBikeRequest !
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
} 
} «
FC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\HistorialUsuarioDto.cs
	namespace 	
MotoSeguraAPI
 
. 
Dtos 
{ 
public 

class 
HistorialUsuarioDto $
{ 
public 
Guid 
UserId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Nombre 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
public 
List 
<  
TrayectoAnalizadoDto (
>( )
	Trayectos* 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
=B C
newD G
(G H
)H I
;I J
} 
}		 ¬
9C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\GpsDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
GpsDto 
{ 
public 
CoordenadasDto 
	Ubicacion '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
=6 7
new8 ;
(; <
)< =
;= >
public 

double 
	Velocidad 
{ 
get !
;! "
set# &
;& '
}( )
public 

double 
Altitud 
{ 
get 
;  
set! $
;$ %
}& '
public 

double 
	Direccion 
{ 
get !
;! "
set# &
;& '
}( )
}		 
} ∞
@C:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\GiroscopioDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
GiroscopioDto 
{ 
public 

bool !
CambioBruscoDireccion %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} …
EC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\EventoDetectadoDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
EventoDetectadoDto #
{ 
public 

string 
Tipo 
{ 
get 
; 
set !
;! "
}# $
=% &
string' -
.- .
Empty. 3
;3 4
public 

DateTime 
	Timestamp 
{ 
get  #
;# $
set% (
;( )
}* +
public 

string 
? 
Detalles 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 π
AC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\CoordenadasDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
CoordenadasDto 
{ 
public 

double 
Lat 
{ 
get 
; 
set  
;  !
}" #
public 

double 
Lng 
{ 
get 
; 
set  
;  !
}" #
} 
} Ω
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\ConectividadDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
ConectividadDto  
{ 
public 

bool 
RedMovil 
{ 
get 
; 
set  #
;# $
}% &
public 

bool 
Wifi 
{ 
get 
; 
set 
;  
}! "
} 
}		 À
BC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\DTOs\AcelerometroDto.cs
	namespace 	
MotoSeguraApi
 
. 
Dtos 
{ 
public 

class 
AcelerometroDto  
{ 
public 

double 
Aceleracion 
{ 
get  #
;# $
set% (
;( )
}* +
public 

bool 
FrenadoBrusco 
{ 
get  #
;# $
set% (
;( )
}* +
} 
}		 ö)
GC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Data\ApplicationDbContext.cs
	namespace 	
MotoSeguraAPI
 
. 
Data 
{ 
public 

class  
ApplicationDbContext %
:& '
	DbContext( 1
{ 
public		  
ApplicationDbContext		 #
(		# $
DbContextOptions		$ 4
<		4 5 
ApplicationDbContext		5 I
>		I J
options		K R
)		R S
:

 
base

 
(

 
options

 
)

 
{ 	
} 	
public 
DbSet 
< 
User 
> 
Users  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DbSet 
< 
Trayecto 
> 
	Trayectos (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
DbSet 
< 
Evento 
> 
Eventos $
{% &
get' *
;* +
set, /
;/ 0
}1 2
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
modelBuilder 
. 
Entity 
<  
Trayecto  (
>( )
() *
)* +
.+ ,
OwnsOne, 3
(3 4
t4 5
=>6 8
t9 :
.: ;
UbicacionInicio; J
)J K
;K L
modelBuilder 
. 
Entity 
<  
Trayecto  (
>( )
() *
)* +
.+ ,
OwnsOne, 3
(3 4
t4 5
=>6 8
t9 :
.: ;
UbicacionFin; G
)G H
;H I
modelBuilder 
. 
Owned 
< 
Gps "
>" #
(# $
)$ %
;% &
modelBuilder 
. 
Entity 
<  
Trayecto  (
>( )
() *
)* +
.+ ,
OwnsOne, 3
(3 4
t4 5
=>6 8
t9 :
.: ;
Gps; >
,> ?
gps@ C
=>D F
{ 
gps 
. 
OwnsOne 
( 
g 
=>  
g! "
." #
	Ubicacion# ,
), -
;- .
} 
) 
; 
modelBuilder   
.   
Entity   
<    
Trayecto    (
>  ( )
(  ) *
)  * +
.  + ,
OwnsOne  , 3
(  3 4
t  4 5
=>  6 8
t  9 :
.  : ;
Acelerometro  ; G
)  G H
;  H I
modelBuilder!! 
.!! 
Entity!! 
<!!  
Trayecto!!  (
>!!( )
(!!) *
)!!* +
.!!+ ,
OwnsOne!!, 3
(!!3 4
t!!4 5
=>!!6 8
t!!9 :
.!!: ;

Giroscopio!!; E
)!!E F
;!!F G
modelBuilder"" 
."" 
Entity"" 
<""  
Trayecto""  (
>""( )
("") *
)""* +
.""+ ,
OwnsOne"", 3
(""3 4
t""4 5
=>""6 8
t""9 :
."": ;
Conectividad""; G
)""G H
;""H I
modelBuilder## 
.## 
Entity## 
<##  
Trayecto##  (
>##( )
(##) *
)##* +
.##+ ,
OwnsOne##, 3
(##3 4
t##4 5
=>##6 8
t##9 :
.##: ;
VerificacionCasco##; L
)##L M
;##M N
modelBuilder'' 
.'' 
Entity'' 
<''  
Trayecto''  (
>''( )
('') *
)''* +
.(( 
HasOne(( 
((( 
t(( 
=>(( 
t(( 
.(( 
User(( #
)((# $
.)) 
WithMany)) 
()) 
u)) 
=>)) 
u))  
.))  !
	Trayectos))! *
)))* +
.** 
HasForeignKey** 
(** 
t**  
=>**! #
t**$ %
.**% &
UserId**& ,
)**, -
.++ 
OnDelete++ 
(++ 
DeleteBehavior++ (
.++( )
Cascade++) 0
)++0 1
;++1 2
modelBuilder// 
.// 
Entity// 
<//  
User//  $
>//$ %
(//% &
)//& '
.00 
HasIndex00 
(00 
u00 
=>00 
u00  
.00  !
Email00! &
)00& '
.11 
IsUnique11 
(11 
)11 
;11 
}55 	
}66 
}77 ∫
HC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Controllers\UserController.cs
	namespace 	
MotoSeguraAPI
 
. 
Controllers #
{ 
[ 
	Authorize 
] 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
UserController

 
:

  !
ControllerBase

" 0
{ 
private 
readonly 
IUserService %
_userService& 2
;2 3
public 
UserController 
( 
IUserService *
userService+ 6
)6 7
{ 	
_userService 
= 
userService &
;& '
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
object% +
)+ ,
,, -
StatusCodes. 9
.9 :
Status200OK: E
)E F
]F G
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
string% +
)+ ,
,, -
StatusCodes. 9
.9 :!
Status401Unauthorized: O
)O P
]P Q
public 
IActionResult 

GetProfile '
(' (
)( )
{ 	
var 
profile 
= 
_userService &
.& '

GetProfile' 1
(1 2
User2 6
)6 7
;7 8
if 
( 
profile 
== 
null 
)  
return 
Unauthorized #
(# $
$str$ M
)M N
;N O
return 
Ok 
( 
profile 
) 
; 
} 	
} 
} â0
LC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Controllers\TrayectoController.cs
	namespace 	
MotoSeguraAPI
 
. 
Controllers #
{ 
[ 
	Authorize 
] 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
TrayectoController #
:$ %
ControllerBase& 4
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
ILogger  
<  !
TrayectoController! 3
>3 4
_logger5 <
;< =
private 
readonly 
IUserService %
_userService& 2
;2 3
public 
TrayectoController !
(! " 
ApplicationDbContext  
context! (
,( )
IMapper 
mapper 
, 
ILogger 
< 
TrayectoController &
>& '
logger( .
,. /
IUserService 
userService $
)$ %
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
_logger   
=   
logger   
;   
_userService!! 
=!! 
userService!! &
;!!& '
}"" 	
[$$ 	
HttpPost$$	 
]$$ 
[%% 	 
ProducesResponseType%%	 
(%% 
typeof%% $
(%%$ %
object%%% +
)%%+ ,
,%%, -
StatusCodes%%. 9
.%%9 :
Status201Created%%: J
)%%J K
]%%K L
[&& 	 
ProducesResponseType&&	 
(&& 
typeof&& $
(&&$ %
string&&% +
)&&+ ,
,&&, -
StatusCodes&&. 9
.&&9 :
Status404NotFound&&: K
)&&K L
]&&L M
public'' 
IActionResult'' 
RegistrarTrayecto'' .
(''. /
[''/ 0
FromBody''0 8
]''8 9
TrayectoDto'': E
dto''F I
)''I J
{(( 	
_logger)) 
.)) 
LogInformation)) "
())" #
$str))# I
)))I J
;))J K
var++ 
userIdClaim++ 
=++ 
User++ "
.++" #
FindFirstValue++# 1
(++1 2

ClaimTypes++2 <
.++< =
NameIdentifier++= K
)++K L
;++L M
if,, 
(,, 
string,, 
.,, 
IsNullOrEmpty,, $
(,,$ %
userIdClaim,,% 0
),,0 1
),,1 2
{-- 
_logger.. 
... 

LogWarning.. "
(.." #
$str..# A
)..A B
;..B C
return// 
Unauthorized// #
(//# $
$str//$ @
)//@ A
;//A B
}00 
if22 
(22 
!22 
Guid22 
.22 
TryParse22 
(22 
userIdClaim22 *
,22* +
out22, /
var220 3
userId224 :
)22: ;
)22; <
{33 
_logger44 
.44 

LogWarning44 "
(44" #
$str44# T
)44T U
;44U V
return55 
Unauthorized55 #
(55# $
$str55$ 5
)555 6
;556 7
}66 
var88 
user88 
=88 
_userService88 #
.88# $
FindById88$ ,
(88, -
userId88- 3
)883 4
;884 5
if99 
(99 
user99 
==99 
null99 
)99 
{:: 
_logger;; 
.;; 

LogWarning;; "
(;;" #
$str;;# N
);;N O
;;;O P
return<< 
NotFound<< 
(<<  
$str<<  8
)<<8 9
;<<9 :
}== 
var?? 
trayecto?? 
=?? 
_mapper?? "
.??" #
Map??# &
<??& '
Trayecto??' /
>??/ 0
(??0 1
dto??1 4
)??4 5
;??5 6
trayecto@@ 
.@@ 
UserId@@ 
=@@ 
userId@@ $
;@@$ %
trayectoBB 
=BB %
AnalizadorTrayectoServiceBB 0
.BB0 1
EnriquecerTrayectoBB1 C
(BBC D
trayectoBBD L
,BBL M
dtoBBN Q
)BBQ R
;BBR S
_contextDD 
.DD 
	TrayectosDD 
.DD 
AddDD "
(DD" #
trayectoDD# +
)DD+ ,
;DD, -
_contextEE 
.EE 
SaveChangesEE  
(EE  !
)EE! "
;EE" #
_loggerGG 
.GG 
LogInformationGG "
(GG" #
$strGG# `
,GG` a
userGGb f
.GGf g
EmailGGg l
)GGl m
;GGm n
returnII 
CreatedAtActionII "
(II" #
nameofII# )
(II) *
RegistrarTrayectoII* ;
)II; <
,II< =
newII> A
{IIB C
trayectoIID L
.IIL M
IdIIM O
}IIP Q
,IIQ R
newIIS V
{JJ 
trayectoKK 
.KK 
IdKK 
,KK 
trayectoLL 
.LL 
FechaInicioLL $
,LL$ %
trayectoMM 
.MM 
ModoConduccionMM '
,MM' (
trayectoNN 
.NN 
EventosNN  
.NN  !
CountNN! &
,NN& '
trayectoOO 
.OO 
VerificacionCascoOO *
?OO* +
.OO+ ,
CascoDetectadoOO, :
}PP 
)PP 
;PP 
}QQ 	
}RR 
}SS Í
MC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Controllers\HistorialController.cs
	namespace 	
MotoSeguraAPI
 
. 
Controllers #
{# $
[ 
ApiController 
] 
[ 
Route 

(
 
$str +
)+ ,
], -
public		 

class		 
HistorialController		 $
:		% &
ControllerBase		' 5
{

 
private 
readonly #
HistorialUsuarioService 0
_historialService1 B
;B C
public 
HistorialController "
(" ##
HistorialUsuarioService# :
historialService; K
)K L
{ 	
_historialService 
= 
historialService  0
;0 1
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
HistorialUsuarioDto /
>/ 0
Get1 4
(4 5
Guid5 9
userId: @
)@ A
{ 	
try 
{ 
var 
	historial 
= 
_historialService  1
.1 2
ObtenerHistorial2 B
(B C
userIdC I
)I J
;J K
return 
Ok 
( 
	historial #
)# $
;$ %
} 
catch 
( 
	Exception 
ex 
)  
{ 
return 
NotFound 
(  
ex  "
." #
Message# *
)* +
;+ ,
} 
} 	
} 
}   ¯
HC:\jaofdev\MotoSeguraBackend\MotoSeguraAPI\Controllers\AuthController.cs
	namespace 	
MotoSeguraAPI
 
. 
Controllers #
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IAuthService %
_authService& 2
;2 3
public 
AuthController 
( 
IAuthService *
authService+ 6
)7 8
{ 	
_authService 
= 
authService &
;& '
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Register) 1
(1 2
UserRegisterDto2 A
dtoB E
)E F
{ 	
var 
success 
= 
await 
_authService  ,
., -
RegisterAsync- :
(: ;
dto; >
)> ?
;? @
if 
( 
! 
success 
) 
return 

BadRequest !
(! "
$str" A
)A B
;B C
return 
Ok 
( 
$str 9
)9 :
;: ;
}   	
["" 	
HttpPost""	 
("" 
$str"" 
)"" 
]"" 
public## 
async## 
Task## 
<## 
IActionResult## '
>##' (
Login##) .
(##. /
UserLoginDto##/ ;
dto##< ?
)##? @
{$$ 	
var%% 
token%% 
=%% 
await%% 
_authService%% *
.%%* +

LoginAsync%%+ 5
(%%5 6
dto%%6 9
)%%9 :
;%%: ;
if&& 
(&& 
token&& 
==&& 
null&& 
)&& 
return'' 
Unauthorized'' #
(''# $
$str''$ =
)''= >
;''> ?
return)) 
Ok)) 
()) 
new)) 
{)) 
token)) !
}))" #
)))# $
;))$ %
}** 	
}-- 
}.. 