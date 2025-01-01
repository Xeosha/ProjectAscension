import { scale } from './metrics';

export const TYPOGRAPHY = {
  // Размеры текста
  sizes: {
    xs: scale(1),
    sm: scale(2),
    md: scale(4),
    lg: scale(8),
    xl: scale(12),
    xxl: scale(24),
    title: scale(32),
  },

  // Жирность текста
  weights: {
    light: '300',
    regular: '400',
    medium: '500',
    semibold: '600',
    bold: '700',
    heavy: '800',
  },

  // Семейства шрифтов (можно настроить под свои шрифты)
  families: {
    regular: 'System',
    medium: 'System',
    bold: 'System',
  },
};