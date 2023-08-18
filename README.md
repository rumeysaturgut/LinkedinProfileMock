Proje içerisinde MVC yapısı bulunmaktadır. DB first ile yazılmış bir yapıdadır ve modelleri güncellemek için scaffold kullandım.
DB ile bağlantı EF ile sağlanmıştır. SQL command query ile datanın çekilmesi durumunda da ekstra olarak RaqwSqlWuery methodu ekledim.

Database bağlanmak için gerekli connection string;

data source=PCUSK0022;initial catalog=linkedin;user id=sa;password=root1234;TrustServerCertificate=true

Database'e bağlanma durumu için bir "sa" user'ı tanımladığım için SQL Authenticator seçeneğini kullandım.