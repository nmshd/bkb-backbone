import 'package:flutter/material.dart';

const lightColorScheme = ColorScheme(
  brightness: Brightness.light,
  primary: Color(0xFF365CA8),
  onPrimary: Color(0xFFFFFFFF),
  primaryContainer: Color(0xFFD9E2FF),
  onPrimaryContainer: Color(0xFF001945),
  secondary: Color(0xFF0060A9),
  onSecondary: Color(0xFFFFFFFF),
  secondaryContainer: Color(0xFFD3E4FF),
  onSecondaryContainer: Color(0xFF001C38),
  tertiary: Color(0xFF9B4500),
  onTertiary: Color(0xFFFFFFFF),
  tertiaryContainer: Color(0xFFFFDBC9),
  onTertiaryContainer: Color(0xFF331200),
  error: Color(0xFFBA1A1A),
  errorContainer: Color(0xFFFFDAD6),
  onError: Color(0xFFFFFFFF),
  onErrorContainer: Color(0xFF410002),
  surface: Color(0xFFF8FDFF),
  onSurface: Color(0xFF001F25),
  onSurfaceVariant: Color(0xFF44464F),
  outline: Color(0xFF757780),
  onInverseSurface: Color(0xFFD6F6FF),
  inverseSurface: Color(0xFF00363F),
  inversePrimary: Color(0xFFB0C6FF),
  shadow: Color(0xFF000000),
  surfaceTint: Color(0xFF365CA8),
  outlineVariant: Color(0xFFC5C6D0),
  scrim: Color(0xFF000000),
);

final cardThemeLight = CardTheme(
  color: lightColorScheme.surface,
  shadowColor: lightColorScheme.shadow,
  surfaceTintColor: lightColorScheme.surfaceTint,
);

const darkColorScheme = ColorScheme(
  brightness: Brightness.dark,
  primary: Color(0xFFB0C6FF),
  onPrimary: Color(0xFF002D6E),
  primaryContainer: Color(0xFF18438F),
  onPrimaryContainer: Color(0xFFD9E2FF),
  secondary: Color(0xFFA2C9FF),
  onSecondary: Color(0xFF00315B),
  secondaryContainer: Color(0xFF004881),
  onSecondaryContainer: Color(0xFFD3E4FF),
  tertiary: Color(0xFFFFB68D),
  onTertiary: Color(0xFF532200),
  tertiaryContainer: Color(0xFF763300),
  onTertiaryContainer: Color(0xFFFFDBC9),
  error: Color(0xFFFFB4AB),
  errorContainer: Color(0xFF93000A),
  onError: Color(0xFF690005),
  onErrorContainer: Color(0xFFFFDAD6),
  surface: Color(0xFF001F25),
  onSurface: Color(0xFFA6EEFF),
  onSurfaceVariant: Color(0xFFC5C6D0),
  outline: Color(0xFF8F9099),
  onInverseSurface: Color(0xFF001F25),
  inverseSurface: Color(0xFFA6EEFF),
  inversePrimary: Color(0xFF365CA8),
  shadow: Color(0xFF000000),
  surfaceTint: Color(0xFFB0C6FF),
  outlineVariant: Color(0xFF44464F),
  scrim: Color(0xFF000000),
);

final cardThemeDark = CardTheme(
  color: darkColorScheme.surface,
  shadowColor: darkColorScheme.shadow,
  surfaceTintColor: darkColorScheme.surfaceTint,
);
