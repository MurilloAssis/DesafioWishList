import { Component } from "react";


export default class Desejos extends Component {
    constructor(props) {
        super(props)
        this.state = {
            listaDesejos: [],
            idUsuario: '',
            titulo: '',
            descricao: '',


        }
    }

    buscarDesejo = () => {

        fetch('http://localhost:5000/api/Desejos',{
            method: 'GET'
        })

            .then(resposta => resposta.json())

            .then(desejos => this.setState({ listaDesejos: desejos }))

            .catch(erro => console.log(erro))
    }

    componentDidMount() {
        this.buscarDesejo();
    }

    atualizarTitulo = async (desejo) => {
        await this.setState({ titulo: desejo.target.value })
        console.log(this.state.titulo)
    }
    atualizaridUsuario = async (desejo) => {
        await this.setState({ idUsuario: desejo.target.value })
        console.log(this.state.idUsuario)
    }
    atualizarDescricao = async (desejo) => {
        await this.setState({ descricao: desejo.target.value })
        console.log(this.state.descricao)
    }

    cadastrarDesejo = (event) => {
        event.preventDefault();
        
        fetch('http://localhost:5000/api/Desejos', {
            method: 'POST',

            body: JSON.stringify({ idUsuario: this.state.idUsuario, titulo: this.state.titulo, descricao: this.state.descricao }),

            headers: { "Content-Type": "application/json" }

        })

            .then(console.log("Desejo cadastrado com sucesso!"))
            .catch(erro => console.log(erro))
            .then(this.limparCampos)
            .then(this.buscarDesejo)


    }

    

    limparCampos = () => {
        this.setState({
            idUsuario: '',
            titulo: '',
            descricao: ''
        })
        console.log('Os campos foram resetados')
    }


    render() {
        return (
            //JSX
            <div >
                <div className="conteiner_W">
                    <section className="wish">
                        <form className="form" onSubmit={this.cadastrarDesejo}>
                            <input type="text" value={this.state.titulo} placeholder="O que deseja..." onChange={this.atualizarTitulo} />
                            <input type="text" value={this.state.descricao} placeholder="Descreva seu desejo..." onChange={this.atualizarDescricao} />
                            <input type="text" value={this.state.idUsuario} placeholder="Coloque seu ID..." onChange={this.atualizaridUsuario} />
                            <button type="submit">Cadastrar</button>
                        </form>
                    </section>
                </div>
                <section>
                    <div className="conteiner_my_wish">
                        <section className="my_wish">
                            <div>
                                <h1>My Wishlist</h1>
                            </div>
                            <div className="table_conteiner">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Titulo</th>
                                            <th>Descrição</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {
                                            this.state.listaDesejos.map((desejos) => {
                                                return (
                                                    <tr key={desejos.idDesejo}>
                                                        <td>{desejos.idDesejo}</td>
                                                        <td>{desejos.titulo}</td>
                                                        <td>{desejos.descricao}</td>
                                                    </tr>
                                                )
                                            })
                                        }
                                    </tbody>
                                </table>
                            </div>
                        </section>
                    </div>
                </section>
            </div>
        )
    }
}