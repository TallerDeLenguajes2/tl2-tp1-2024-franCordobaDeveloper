# tl2-tp1-2024-Cordoba Francisco Javier

1.  ¿Cuál de estas relaciones considera que se realiza por composición y cuál por
    agregación?

    La tabla Pedidos presenta una asociacion del tipo "Composicion" con la tabla Cliente, dado que un Cliente es parte de un Pedido

    La tabla Cadete con la tabla Cadeteria presenta una asociacion del tipo "Agregacion" 

2. ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

    Cadete podria tener un metodo que calcule la plata a cobrar de su jornal descontando la plata que el utilizo en nafta (en caso de contar con un vehiculo que consuma combustible).
    
    Cadete podria contar con metodo que indique que acepto un pedido. Para cambiar el estado del pedido a pendiente y luego a entregado.

    Cadeteria deberia tener un metodo que analize el estado de un pedido

3. Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles
   privados.

   Teniendo en cuenta el principo de Encapsulamiento los datos(Atributos) deberia ser privados tomando como ejemplo la Tabla Cliente
   sus campos Como ser nombre, dirrecion, telefono y referencia a su direccion deberia ser privados y solo accesibles ultilizando los metodo setter y getter.

   Podriamos tener un metodo que sea publico que liste el total de cliente.

4. ¿Cómo diseñaría los constructores de cada una de las clases?


   

