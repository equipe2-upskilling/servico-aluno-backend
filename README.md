# Grupo2_Student_Server

## Esse é o serviço que abrigar as funções de estudantes.

### Nele contém as seguintes entities.
-Studenthen <br/>
-Course(Apenas para ligações)<br/>
-Lesson(Apenas para ligações)<br/>
-StudentCourse ( A Relação entre Student e Course)<br/>
-StudentCourseLesson ( A Relação entre Student, Course e Lesson)<br/>

 ## Arquitetura

### Banco de Dados
Foi usado o Elephant(banco de Daods Postgres) para a persitencia dos dados.
________________________________________________________________________________

O Server foi construido em modelo de Domain, Infrasctuture, Application, CrossCutting, API e ConsumerSQS.

### Domain

Contém as informações de entities , os enums, as interfaces dos respository para os entities.

### Infrasctuture

Contém as informações de DbContext onde possui as configurações de bancos, migrations , Repository das interfaces dos entities. e ela se comunina com o Domain apenas.

### Application

Contém as informações de Dtos, Interfaces de services, as implementações de services e os Mappings onde fazer um automapper dos dtos para entities e ela se comunina com o Domain apenas.

### CrossCutting

Contém as informações de Injeções de Depedencias. Nela contém os addscoped para as interfaces para repositorios, o caminho do banco e é configurado o automapper. E ela se comunia com Domain,Application e Infrasctuture.

### API

Contém as informações de Controller, ModelViews, Extensões para a aplicação, filtro de autenticação e um producer de AWS para o envio para as filas de boletos e certificados. E ela se comunina com CrossCutting apenas.

### ConsumerSQS

Contém as informações para que ele possa receber da fila informações para ser processada de um outro serviço de boleto e certificados.

