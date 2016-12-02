#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

#endregion

namespace Sniper_Zombie
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		Texture2D mira;
		Texture2D fondo1;
		Texture2D zombie1;
		Texture2D zombie2;
		Texture2D zombie3;
		Texture2D arbol1, arbol2, arbol3, arbol5;
		Texture2D menu;
		Texture2D valla;
		Texture2D valla02;
		Texture2D valla03;
		Texture2D animacion;

		Vector2 posicion_mira;
		Vector2 posicion_fondo1;
		Vector2 posicion_zombie;
		Vector2 posicion_zombie2;
		Vector2 posicion_zombie3;
		Vector2 posicion_fuente;
		Vector2 posicion_valla;
		Vector2 posicion_valla02;
		Vector2 posicion_valla03;
		Vector2 posicion_fuente2;
		Vector2 posicion_puntaje;
		Vector2 posicion_tiempo;
		Vector2 posicion_fuente3;
		Vector2 posicionanim;

		Rectangle rectangulo_mira;
		Rectangle rectangulo_zombie1;
		Rectangle rectangulo_zombie2;
		Rectangle rectangulo_zombie3;
		Rectangle inicio;
		Rectangle fin;
		Rectangle rectangulo_fuente;
		Rectangle rectangulo_fuente2;
		Rectangle recanimacion;
		Rectangle[] recvector = new Rectangle[6];

		SoundEffect tiro;
		SoundEffect carga;
		Song fondo_juego;
		Song sonidomenu;



		bool tiro_mouse = false;
		bool ClickDerecho = false;
		bool menu_bool = true;
		bool animacionb = false;

		Color color_zombie = Color.White;
		Color color_zombie2 = Color.White;
		Color color_zombie3 = Color.White;
		Color color_menu = Color.White;
		Color color_fuente = Color.Red;
		Color color_fuente2 = Color.Red;
		Color color_final = Color.Transparent;
		Color color_puntos = Color.YellowGreen;
		Color color_tiempo = Color.YellowGreen;
		Color color_animacion = Color.Transparent;

		float escala = 1;

		Random aparece_zombie = new Random();

		SpriteFont fuente;
		SpriteFont fuentesalir;
		SpriteFont puntaje;
		SpriteFont puntostiempo;
		SpriteFont puntosfinal;

		int tiempo = 0;
		int avance = 1;
		int avance2 = 2;
		int avance3 = 3;
		int acumulador = 0;
		int tiempopuntos = 0;
		int segundos = 0;
		int i=0;
		int tiempoanimacion = 0;
		int posicionanimacion = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "../../Content";	            
			graphics.IsFullScreen = false;		
        }

        
        protected override void Initialize()
        {
			Window.Title = "Sniper Z";

			IsMouseVisible = false; 

			graphics.PreferredBackBufferWidth = 640; 
			graphics.PreferredBackBufferHeight = 480;

			posicion_mira = new Vector2 (0,0);
			posicion_fondo1 = Vector2.Zero;
			rectangulo_mira = new Rectangle (0,0,2,2);
			posicion_zombie = new Vector2 (320,240);
			rectangulo_zombie1 = new Rectangle ((int)posicion_zombie.X, (int)posicion_zombie.Y, 100, 180);
			posicion_zombie2 = new Vector2 (95,250);
			rectangulo_zombie2 = new Rectangle ((int)posicion_zombie2.X, (int)posicion_zombie2.Y,70, 140);
			posicion_zombie3 = new Vector2 (500,280);
			posicion_fuente = new Vector2 (295,205);
			rectangulo_fuente = new Rectangle (295,205,50,20);
			posicion_fuente2 = new Vector2 (295,250);
			rectangulo_fuente2 = new Rectangle (295,250,60,30);
			posicion_puntaje = new Vector2 (50,50);
			posicion_tiempo = new Vector2 (50,25);
			posicion_fuente3 = new Vector2 (100,100);
			rectangulo_zombie3 = new Rectangle ((int)posicion_zombie3.X, (int)posicion_zombie3.Y, 50, 89);
			inicio = new Rectangle (0, 0, 1, 480);
			fin = new Rectangle (640,0,1,480);
			posicion_valla = new Vector2 (200,390);
			posicion_valla02 = new Vector2 (20,370);
			posicion_valla03 = new Vector2 (20,355);

            base.Initialize();
				
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

			fondo1 = Content.Load<Texture2D>("fondo2");
			arbol1 = Content.Load<Texture2D> ("arbol1");
			arbol2 = Content.Load<Texture2D> ("arbol2");
			arbol3 = Content.Load<Texture2D> ("arbol3");
			arbol5 = Content.Load<Texture2D> ("arbol5");
			mira = Content.Load<Texture2D>("miraa");
			tiro = Content.Load<SoundEffect> ("2");
			carga = Content.Load<SoundEffect> ("carga.wav");
		    sonidomenu = Content.Load<Song> ("sonidomenu.wav");
			fondo_juego = Content.Load<Song> ("fondosonido.wav");
			zombie1 = Content.Load<Texture2D> ("zombie100x180");
			zombie2 = Content.Load<Texture2D> ("zombie2");
			zombie3 = Content.Load<Texture2D> ("zombie3");
			menu = Content.Load<Texture2D> ("fondomenu");
			fuente = Content.Load<SpriteFont> ("fuente1");
			fuentesalir = Content.Load<SpriteFont> ("fuente1");
			puntaje = Content.Load<SpriteFont> ("fuente1");
			puntostiempo = Content.Load<SpriteFont> ("fuente1");
			puntosfinal = Content.Load<SpriteFont> ("fuente1");
			valla = Content.Load<Texture2D> ("valla");
			valla02 = Content.Load<Texture2D> ("valla02");
			valla03= Content.Load<Texture2D> ("valla03");
			animacion = Content.Load<Texture2D> ("madera");

			for (i=0; i<6; i++)
				recvector [i] = new Rectangle (60 * i, 0, 60, 61);
			    
			recanimacion = new Rectangle (0, 0, 60, 61);

        }


      
        protected override void Update(GameTime gameTime)
		{
            
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) 
				this.Exit ();

			KeyboardState keyboard = Keyboard.GetState ();
				
			//if (keyboard.IsKeyDown (Keys.Escape))
				//this.Exit ();

			MouseState mouse = Mouse.GetState ();

			posicion_mira.X = (int)mouse.X - 870;
			posicion_mira.Y = (int)mouse.Y - 744;
			rectangulo_mira.X = (int)mouse.X;
			rectangulo_mira.Y = (int)mouse.Y;

			if ((mouse.LeftButton == ButtonState.Pressed) && (tiro_mouse == true)) {
				tiro_mouse = false;
				ClickDerecho = true;


			} else
				ClickDerecho = false;
			   

			if (mouse.LeftButton == ButtonState.Released)
				tiro_mouse = true;



			if (ClickDerecho == true) {
	

				if (rectangulo_zombie1.Contains (rectangulo_mira)) {
					posicion_zombie.X = aparece_zombie.Next (0, 600);
					rectangulo_zombie1.X = (int)posicion_zombie.X;
					acumulador = acumulador + 1;
					color_animacion = Color.White;
					animacionb = true;
					escala = 1;
				}
				if (rectangulo_zombie2.Contains (rectangulo_mira)) {

					posicion_zombie2.X = aparece_zombie.Next (0, 600);
					rectangulo_zombie2.X = (int)posicion_zombie2.X;
					acumulador = acumulador + 3;
					color_animacion = Color.White;
					animacionb = true;
					escala = 0.6f;
				}
				if (rectangulo_zombie3.Contains (rectangulo_mira)) {

					posicion_zombie3.X = aparece_zombie.Next (0, 600);
					rectangulo_zombie3.X = (int)posicion_zombie3.X;
					acumulador = acumulador + 5;
					color_animacion = Color.White;
					animacionb = true;
					escala = 0.4f;
				}
				tiro_mouse = false;
			}

			if ((ClickDerecho == true) && (color_menu == Color.Transparent)) 
				tiro.Play ();
			  
		

			if (rectangulo_fuente.Contains (rectangulo_mira)) {

				if (ClickDerecho == true) {
					color_menu = Color.Transparent;
					carga.Play ();
					color_final = Color.Transparent;
					color_tiempo = Color.YellowGreen;
					color_puntos = Color.YellowGreen;
					color_zombie = Color.White;
					color_zombie2 = Color.White;
					color_zombie3 = Color.White;
					acumulador = 0;
					segundos = 0;

				}

			}


			if (rectangulo_fuente.Contains (rectangulo_mira)) 
			{
				color_fuente = Color.Orange;

			}
			else 
				color_fuente = Color.Red;
				
			
			if (color_menu == Color.Transparent) 
				color_fuente = Color.Transparent;


			if (rectangulo_fuente2.Contains (rectangulo_mira))
			    color_fuente2 = Color.Orange; 
			else 
				color_fuente2 = Color.Red;


			if (color_menu == Color.Transparent) 
				color_fuente2 = Color.Transparent;

			if (((mouse.LeftButton == ButtonState.Pressed) && (rectangulo_fuente2.Contains (rectangulo_mira)) && (color_menu == Color.White)))
			{
				carga.Play ();
				this.Exit ();
			}

			     
			    if (keyboard.IsKeyDown (Keys.D1)) MediaPlayer.Volume = 0.1f;
			    if (keyboard.IsKeyDown (Keys.D2)) MediaPlayer.Volume = 0.2f;
			    if (keyboard.IsKeyDown (Keys.D3)) MediaPlayer.Volume = 0.3f;
			    if (keyboard.IsKeyDown (Keys.D4)) MediaPlayer.Volume = 0.4f;
			    if (keyboard.IsKeyDown (Keys.D5)) MediaPlayer.Volume = 0.5f;
			    if (keyboard.IsKeyDown (Keys.D6)) MediaPlayer.Volume = 0.6f;
			    if (keyboard.IsKeyDown (Keys.D7)) MediaPlayer.Volume = 0.7f;
			    if (keyboard.IsKeyDown (Keys.D8)) MediaPlayer.Volume = 0.8f;
			    if (keyboard.IsKeyDown (Keys.D9)) MediaPlayer.Volume = 1.0f;



			tiempo = tiempo + (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			if (tiempo > 10) 
			{
				posicion_zombie2.X += avance2;
				rectangulo_zombie2.X += avance2;
				posicion_zombie.X += avance;
				rectangulo_zombie1.X += avance;
				posicion_zombie3.X += avance3;
				rectangulo_zombie3.X += avance3;
				tiempo = 0;
			}

			if (color_menu == Color.Transparent) 
			{
				tiempopuntos = tiempopuntos + (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			}

			if ((tiempopuntos >= 1000) && (color_menu == Color.Transparent))
			{
				segundos++;
				tiempopuntos = 0;

			}

			if ((rectangulo_zombie1.X <= 200) || (rectangulo_zombie1.X >= 350))
			    avance = avance*-1;

			if ((rectangulo_zombie2.Intersects(inicio)) || (rectangulo_zombie2.Intersects(fin)))
				avance2 = avance2*-1;

			if ((inicio.Intersects(rectangulo_zombie3)) || (fin.Intersects(rectangulo_zombie3)))
				avance3 = avance3*-1;


			if ((color_menu == Color.White) && (menu_bool == true))
			{
				MediaPlayer.Play (sonidomenu); 
				MediaPlayer.IsRepeating = true; 
				MediaPlayer.Volume = 0.8f;
				menu_bool = false;
			} 

			if ((color_menu == Color.Transparent) && (menu_bool == false))
			{
				MediaPlayer.Play (fondo_juego);
				MediaPlayer.IsRepeating = true; 
				MediaPlayer.Volume = 0.8f;
				menu_bool = true;
			}

			if (segundos == 30)
			{
				color_final = Color.White;
		        color_tiempo = Color.Transparent;
				color_puntos = Color.Transparent;
				color_zombie = Color.Transparent;
				color_zombie2 = Color.Transparent;
				color_zombie3 = Color.Transparent;
			}
			 
			if ((keyboard.IsKeyDown (Keys.Escape)) && (color_menu == Color.Transparent)) 
			{
				color_menu = Color.White;
				segundos = 0;
				acumulador = 0;
			}

			tiempoanimacion = tiempoanimacion + (int)gameTime.ElapsedGameTime.TotalMilliseconds;

			if ((tiempoanimacion > 100) && (animacionb == true))
			{
				posicionanimacion++;

				if (posicionanimacion > 5) 
				{
					posicionanimacion = 0;
					color_animacion = Color.Transparent;
					animacionb = false;
				}

			}

			posicionanim.X = rectangulo_mira.X;
			posicionanim.Y = rectangulo_mira.Y;


			recanimacion = recvector[posicionanimacion];

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           	graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
		
			spriteBatch.Begin ();

			spriteBatch.Draw(fondo1, posicion_fondo1, Color.White);
			spriteBatch.Draw (zombie3, posicion_zombie3, color_zombie3);
			spriteBatch.Draw (valla03, posicion_valla03, Color.White);
			spriteBatch.Draw(arbol5, posicion_fondo1, Color.White);
			spriteBatch.Draw(arbol3, posicion_fondo1, Color.White);
			spriteBatch.Draw(arbol2, posicion_fondo1, Color.White);
			spriteBatch.Draw (zombie2, posicion_zombie2,color_zombie2);
			spriteBatch.Draw (valla02, posicion_valla02, Color.White);
			spriteBatch.Draw (zombie1, posicion_zombie,color_zombie);
			spriteBatch.Draw (valla, posicion_valla, Color.White);
			spriteBatch.Draw(arbol1, posicion_fondo1, Color.White);
			spriteBatch.Draw (mira, posicion_mira, Color.White);
			spriteBatch.DrawString (puntosfinal, "PUNTAJE OBTENIDO: " + acumulador, posicion_fuente3, color_final);
			spriteBatch.DrawString (puntostiempo, "TIEMPO: " + segundos, posicion_tiempo, color_tiempo);
			spriteBatch.DrawString (puntaje, "PUNTOS:" + acumulador, posicion_puntaje, color_puntos);
			spriteBatch.Draw(menu, posicion_fondo1, color_menu);
			spriteBatch.DrawString (fuente, "JUGAR", posicion_fuente, color_fuente);
			spriteBatch.DrawString (fuentesalir, "SALIR", posicion_fuente2, color_fuente2);
			spriteBatch.Draw (animacion, posicionanim, recanimacion, color_animacion,0,new Vector2(0,0),escala,SpriteEffects.None,0);
			spriteBatch.End ();
            
            base.Draw(gameTime);
        }
    }
}

