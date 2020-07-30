import React, { Component } from 'react';

import {Header, Main, Block, Input} from 'components'

class Home extends Component {
    render() {
        return (
            <section className = "home">
                <Header/>
                <Main/>
            </section>
        );
    }
}

export default Home