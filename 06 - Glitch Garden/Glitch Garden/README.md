# Tópicos tratados nesse projeto
* Como fazer uma splash screen utilizando corrotina
* Mais sobre relacionamento parent-child.

## Canvas
* Mais sobre Scaling e Ancoragem.
* Mais sobre Canvas e World Unit
* World Space Canvas Mode
    * Faz com que os elementos do Canvas apareçam no mundo do jogo.
* Converter as coordenadas do canvas para grids na tela.
    * Exemplo: A coordenada 1,1 referênciar a primeira célula da última linha.

## Animação
* Animation e Animator controller
    * O Controller gerencia as Animations.
* Spritesheet animation
* Keyframe Animation
    * É possível mover um objeto atravéz de animação.
* Animation event
    * Torna possível chamar um método durante um frame de animação.
* Animation entre parent-child.
    * Os scripts e o Animator controller devem estar no parent object
    * O Animator controller do pai consegue o sprite do filho.
    * Porém, os objetos filhos não acessam os sprites do pai.
    * Os animation events acessam somente seus próprios scripts ou de seus pais.

## Física e colisão
* Checar se a colisão possuí determinado componente.