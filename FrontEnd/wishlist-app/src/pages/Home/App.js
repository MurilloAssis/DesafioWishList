
// import estrelas from "../../assests/page home.png"
import './App.css';


function rota() {

  window.location.href = 'http://localhost:3000/desejos'
}

function App() {
  return (
    <div className="App">
      <body className="App-header">
        <header>
          <div className="container">

            <button className="logo"><span>Wishlist</span></button>

            <nav className="nav">
              <ul>
                <li><a href="#home">HOME</a></li>
                <li><a href="#about">MY WISHLIST</a></li>
              </ul>
            </nav>


          </div>
        </header>
        <section>
          <div className="container">
            <div className="row min-vh-100 align-items-center text-center text-md-left">

              <div className="col-md-6 pr-md-5 " data-aos="zoom-in">
                <div className="btms">
                  <button onClick={() => rota()}>Cadastrar um Desejo </button>
                  <button onClick={() => rota()}>Meus Desejos</button>
                </div>
              </div>
              <div className="col-md-6 pl-md- content" data-aos="fade-left">
                <img src="src\assests\Online wishes list-pana.svg" alt=""></img>
              </div>

            </div>

          </div>


        </section>

      </body>
    </div >
  );
}

export default App;
