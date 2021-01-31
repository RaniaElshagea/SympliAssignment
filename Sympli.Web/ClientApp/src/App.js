import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { SearchSiteOccurences } from './components/SearchSiteOccurences';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={SearchSiteOccurences} />
        <Route path='/searchsiteoccurences' component={SearchSiteOccurences} />
      </Layout>
    );
  }
}
