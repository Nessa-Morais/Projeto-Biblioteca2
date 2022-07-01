using Biblioteca.Models;
using System.Security.Cryptography;

using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;



namespace Biblioteca.Controllers
{
    public  class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {   
            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("login")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }



        public static bool verificaLoginSenha(string login, string senha, Controller controller){

            using (BibliotecaContext bc = new BibliotecaContext())
            { 

                verificarSeAdminExiste(bc);
              
                string s = Cryptographya.TextoCryptographado(senha); 

                IQueryable<Usuario> UsuarioEncontrado = bc.Usuarios.Where(u => u.Login==login && u.Senha==s);
                List<Usuario> listaUsuarioEncontrado = UsuarioEncontrado.ToList();

                if(listaUsuarioEncontrado.Count == 0){
                    return false;

                }else{ 
                    controller.HttpContext.Session.SetString("login",listaUsuarioEncontrado[0].Login);
                    controller.HttpContext.Session.SetString("nome",listaUsuarioEncontrado[0].Nome);
                    controller.HttpContext.Session.SetInt32("tipo",listaUsuarioEncontrado[0].Tipo);
                    return true;
                }

                 
            }
        }

        public static void verificarSeAdminExiste(BibliotecaContext bc){
             IQueryable<Usuario> UsuarioEncontrado = bc.Usuarios.Where(u => u.Login == "admin");
                if(UsuarioEncontrado.ToList().Count == 0){

                    Usuario admin = new Usuario();
                    admin.Nome ="Administrador";
                    admin.Login="admin"; 
                    admin.Senha=Cryptographya.TextoCryptographado("123");
                    admin.Tipo = Usuario.ADMIN;

                    bc.Usuarios.Add(admin);
                    bc.SaveChanges();
                }
        }

        

 
        public static void verificaSeUsuarioAdmin(Controller controller){
            if(!( controller.HttpContext.Session.GetInt32("tipo")==Usuario.ADMIN)){
                controller.Request.HttpContext.Response.Redirect("/Usuario/NeedAdmin");
            }
        }
    }
}