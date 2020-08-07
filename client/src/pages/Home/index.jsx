import React, { Component } from 'react';

import {Header, Main, Block, Input} from 'components'
import SqzLinkCreator from 'modules/UrlCreator'

class Home extends Component {
    render() {
        return (
            <section className = "home">
                <Header/>
                <Main>
                    <SqzLinkCreator/>
                </Main>
            </section>
        );
    }
}

export default Home