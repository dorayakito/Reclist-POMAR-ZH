# 🍎 RECLIST - POMAR ZH

### Lista de gravação para confecção de voicebanks em Chinês-Mandarim para os softwares UTAU e OpenUtau

---

Esta é uma lista de gravação Chinesa criada por **Dorayakito/Xiao Pingguo (小苹果)**. Ela é baseada nos fonemas mais proeminentes do **普通话/现代标准汉语** (Putonghua/Mandarim Padrão Moderno).

> [!NOTE]
> Esta lista faz parte do projeto **POMAR LTS**.
> 
> 🔗 [POMAR LTS](https://github.com/studiopomar)

---

## 📑 Índice

- [Sobre a Lista](#-sobre-a-lista)
- [Estrutura Fonética](#-estrutura-fonética)
- [Como Gravar](#-como-gravar)
- [Pinyin e Fonemas](#-pinyin-e-fonemas)
- [Tons do Mandarim](#-tons-do-mandarim)
- [Arquivos Inclusos](#-arquivos-inclusos)
- [Créditos e Licença](#-créditos-e-licença)

---

## 📖 Sobre a Lista

Ao baixar a lista de gravação você pode observar que os fonemas apresentam somente **1-mora** (uma linha - retilíneo), como um **CV (consoante-vogal)**, mas a gravação deve seguir o estilo **CV-VC (consoante-vogal + vogal-consoante)**.

### Exemplos de Gravação

| Notação na Lista | Como Gravar |
|------------------|-------------|
| `bang` | `bang_bang` |
| `mei` | `mei_mei` |
| `liu` | `liu_liu` |
| `zhuang` | `zhuang_zhuang` |

> [!IMPORTANT]
> Sempre repita a sílaba duas vezes ao gravar, mesmo que a lista mostre apenas uma vez!

---

## 🔤 Estrutura Fonética

O Mandarim Padrão possui uma estrutura silábica bem definida:

### Iniciais (声母 - Shēngmǔ)

| Tipo | Fonemas |
|------|---------|
| **Labiais** | b, p, m, f |
| **Alveolares** | d, t, n, l |
| **Velares** | g, k, h |
| **Palatais** | j, q, x |
| **Retroflexos** | zh, ch, sh, r |
| **Dentais** | z, c, s |
| **Semivogais** | y, w |

### Finais (韵母 - Yùnmǔ)

| Tipo | Fonemas |
|------|---------|
| **Simples** | a, o, e, i, u, ü |
| **Compostas** | ai, ei, ao, ou |
| **Nasais** | an, en, ang, eng, ong |
| **Especiais** | ia, ie, iao, iou, ian, in, iang, ing, iong |
| **Com ü** | üe, üan, ün |
| **Com u** | ua, uo, uai, uei, uan, uen, uang, ueng |

---

## 🎙️ Como Gravar

### 🎧 Usando VIICTOR YUEBING como Referência

Para facilitar a gravação, podes usar meu voicebank **[VIICTOR](https://vsynthbr.fandom.com/pt-br/wiki/VIICTOR) YUEBING** como auxiliar de pronúncia e configuração:

#### Passo a Passo

1. **Baixe o VIICTOR YUEBING**
   - Faça o download do voicebank completo: [VIICTOR-VCCV-月餅.rar](https://drive.google.com/file/d/1U_cH1Yc7aEePmEncj-EoOqG57_lJPZAC/view?usp=sharing)
   - Extraia em uma pasta de fácil acesso

2. **Escute as Samples de Referência**
   - Navegue até a pasta de samples do VIICTOR YUEBING
   - Ouça cada fonema antes de gravar
   - Preste atenção na entonação e articulação

3. **Grave por Cima (Método Overlay)**
   - No OREMO/Copaiba, carregue a pasta do VIICTOR YUEBING
   - Escute a sample original
   - Grave sua versão mantendo o mesmo timing e pronúncia
   - Substitua os arquivos com suas gravações

4. **Use a oto.ini como Base**
   - Copie o arquivo `oto.ini` do VIICTOR YUEBING
   - Cole na pasta do seu novo voicebank
   - Ajuste os valores conforme necessário para sua voz utilizando SetParam, vLabeler, UTAlet ou Copaiba Lexicon/web.
   - Isso economiza horas de configuração manual!

> [!TIP]
> O VIICTOR YUEBING já possui uma oto.ini bem configurada. Usar ela como base garante que seu voicebank terá aliases compatíveis com o mesmo phonemizer!

### Preparação

1. Prepare seu microfone e ambiente de gravação
2. Abra o software de gravação (OREMO, Akorin, Recst, Copaiba Acácia, etc.)
3. Carregue a lista POMAR ZH (ou use as samples do VIICTOR YUEBING como guia)

### Durante a Gravação

1. **Mantenha um ritmo constante** - Use um metrônomo se necessário
2. **Respire adequadamente** - Não force a voz
3. **Articule claramente** - O Mandarim tem sons específicos que exigem precisão
4. **Compare com a referência** - Ouça o VIICTOR YUEBING antes de cada gravação se tiver dúvidas

### Dicas Importantes

> [!TIP]
> - Para as retroflexas (zh, ch, sh, r), curve a língua para trás
> - Para o som "ü", faça um "i" com os lábios arredondados como "u"
> - Os sons "j, q, x" são palatais - pronuncie com a língua no céu da boca
> - **Dica extra:** Use o VIICTOR YUEBING em loops no OpenUtau para treinar a pronúncia antes de gravar!

---

## 🀄 Pinyin e Fonemas

### Mapeamento de Sons Especiais

| Pinyin | Pronúncia Aproximada | Exemplo |
|--------|---------------------|---------|
| zh | "dj" retroflex | zhōng (中) |
| ch | "tch" retroflex | chī (吃) |
| sh | "x" retroflex | shì (是) |
| r | "r" retroflex suave | rén (人) |
| j | "dj" palatal | jiā (家) |
| q | "tch" palatal aspirado | qī (七) |
| x | "ch" palatal | xīn (新) |
| c | "ts" aspirado | cài (菜) |
| z | "dz" | zài (在) |

---

## 🎵 (Para conhecimento) Tons do Mandarim

O Mandarim possui **4 tons principais** + 1 tom neutro:

| Tom | Símbolo | Descrição | Exemplo |
|-----|---------|-----------|---------|
| 1º | ˉ (āáǎà) | Alto e contínuo | mā (妈) - mãe |
| 2º | ˊ | Ascendente | má (麻) - cânhamo |
| 3º | ˇ | Descendente-ascendente | mǎ (马) - cavalo |
| 4º | ˋ | Descendente | mà (骂) - xingar |
| Neutro | - | Leve e curto | ma (吗) - partícula |

> [!NOTE]
> Esta lista é projetada para gravação **monotônica** (um tom por pitch). Isso quer dizer que você não precisa se preocupar com os 4 tons principais do Mandarim.
> Para voicebanks multitonais, grave a lista completa em diferentes pitches.

---

## 📁 Arquivos Inclusos

```
POMAR_ZH/
├── README.md           # Este arquivo
├── reclist.txt         # Lista de gravação principal
└── oto.ini             # Configuração OTO base (template)
```

---

## ⚙️ Compatibilidade

| Software | Status |
|----------|--------|
| UTAU | ✅ Totalmente compatível |
| OpenUtau | ✅ Totalmente compatível |
| Utsu | ✅ Totalmente compatível |
| NiaoNiao | ✅ Totalmente compatível |
| Projeto Saturno | ✅ Totalmente compatível |
| DeepVocal | ⚠️ Requer conversão |
| Cadencii | ⚠️ Requer conversão |

---

## 📜 Créditos e Licença

### Criador
**Dorayakito / Xiao Pingguo (小苹果)**

Você pode:
- ✅ Usar para criar voicebanks pessoais
- ✅ Modificar e adaptar a lista
- ✅ Compartilhar com atribuição

Você deve:
- 📝 Dar crédito ao criador
- 🔗 Linkar para o projeto original

---

<div align="center">

**POMAR ZH - Sua porta de entrada para voicebanks em Mandarim!**

</div>
