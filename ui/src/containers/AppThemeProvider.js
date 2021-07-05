import React from 'react'
import PropTypes from 'prop-types'
import { ThemeProvider } from 'styled-components'
import theme from '../theme'

export const AppThemeProviderWrapper = ({ children }) => {
  return <ThemeProvider theme={theme}>{children}</ThemeProvider>
}

AppThemeProviderWrapper.propTypes = {
  children: PropTypes.node.isRequired
}

export default AppThemeProviderWrapper
